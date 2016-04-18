using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Windows.Media.Imaging;
using AForge;
using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Video.FFMPEG;
using Size = System.Drawing.Size;

namespace Controller
{
    class Camera
    {
        /// <summary>
        /// 目标设备源
        /// </summary>
        private FilterInfo tarDevice;
        /// <summary>
        /// 用于录制视频
        /// </summary>
        private VideoFileWriter writer;
        /// <summary>
        /// UI界面上的显示控件
        /// </summary>
        private VideoSourcePlayer videoSourcePlayer;

        FilterInfoCollection videoDevices;
        #region INSTANCE
        /// <summary>
        /// 静态单例
        /// </summary>
        private static Camera _instance = null;
        /// <summary>
        /// 用于单例模式的同步检测
        /// </summary>
        private static readonly object SynObject = new object();
        /// <summary>
        /// 私有构造
        /// </summary>
        private Camera()
        {
            tarDevice = null;
            writer = null;
            videoSourcePlayer = null;
        }

        /// <summary>
        /// 获得该类的单例
        /// </summary>
        public static Camera Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (SynObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new Camera();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion INSTANCE

        /// <summary>
        /// 初始化
        /// 设置UI控件，枚举视频输入设备。
        /// </summary>
        /// <param name="player"></param>
        public void Init(VideoSourcePlayer player, ComboBox combobox)
        {

            try
            {
                
                videoSourcePlayer = player;
                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                    throw new ApplicationException();
                for (int i = 0; i < videoDevices.Count; i++)
                {
                    combobox.Items.Add(videoDevices[i].Name);
                    if (videoDevices[i].Name == "WDM 2860 Capture")
                    {
                        tarDevice = videoDevices[i];
                        combobox.SelectedIndex = i;
                    }
                }
                if(combobox.SelectedIndex == -1 && combobox.Items.Count != 0)
                {
                    tarDevice = videoDevices[0];
                    combobox.SelectedIndex = 0;
                }
            }
            catch (ApplicationException)
            {
                System.Diagnostics.Debug.WriteLine("No Camera ");
                tarDevice = null;
            }
        }

        /// <summary>
        /// 连接摄像头
        /// </summary>
        public void ConnectCamera()
        {
            if(videoSourcePlayer != null)
            {
                VideoCaptureDevice videoSource = new VideoCaptureDevice(tarDevice.MonikerString);
                //videoSource.DesiredFrameSize = new System.Drawing.Size(320, 240);
                videoSource.DesiredFrameRate = 120;
                videoSourcePlayer.VideoSource = videoSource;
                videoSourcePlayer.Start();
            }
            
        }

        /// <summary>
        /// 关闭摄像头
        /// </summary>
        public void CloseCamera()
        {
            if (videoSourcePlayer != null)
            {
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
            }

        }
        /// <summary>
        /// 开始视频录制
        /// </summary>
        public void StartRecord(string filepath)
        {
            if(videoSourcePlayer != null)
            {
                writer = new VideoFileWriter();
                writer.Open(@filepath, 640, 480, 25, VideoCodec.MPEG2);
                videoSourcePlayer.NewFrame += VideoSourcePlayer_NewFrame;
            }
        }

        /// <summary>
        /// 视频源有新的帧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="image"></param>
        private void VideoSourcePlayer_NewFrame(object sender, ref System.Drawing.Bitmap image)
        {
            if (writer != null)
            {
                writer.WriteVideoFrame(image);
            }
        }
        /// <summary>
        /// 停止录制视频
        /// </summary>
        public void StopRecord()
        {
            if(videoSourcePlayer != null)
            {
                videoSourcePlayer.NewFrame -= VideoSourcePlayer_NewFrame;
                if (writer != null)
                {
                    writer.Close();
                }
            }

        }

        public void SetCamInputSrc(int idx)
        {
            if(videoDevices != null && videoDevices.Count > idx)
            {
                tarDevice = videoDevices[idx];
            }
        }
    }
}
