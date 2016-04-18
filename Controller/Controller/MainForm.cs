using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
namespace Controller
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 地图上地标等物体的存放面板
        /// </summary>
        GMapOverlay overlayOne = new GMapOverlay();
        /// <summary>
        /// 鼠标按下时记录其代表的经纬度
        /// </summary>
        PointLatLng downpoint;
        /// <summary>
        /// 鼠标松开时记录其代表的经纬度
        /// </summary>
        PointLatLng uppoint;
        /// <summary>
        /// 返航点
        /// </summary>
        PointLatLng homepoint;
        /// <summary>
        /// 拖动画图时
        /// </summary>
        bool bDraw = false;
        /// <summary>
        /// 鼠标左键按下判断
        /// </summary>
        bool isMouseDown = false;

        /// <summary>
        /// 巡航路径
        /// </summary>
        List<PointLatLng> Pathes;

        /// <summary>
        /// 巡航边角， 目前是矩形四个顶点
        /// </summary>
        List<PointLatLng> Range;
        /// <summary>
        /// 当前所处的路径点，得到路径后设置为-1;每到达一个路径点后更新
        /// </summary>
        int CurrentLocationIdx;
        
        Dictionary<int, UInt32> timestamp;

        /// <summary>
        /// 得到时间戳。但是遇见过卡在此处的现象，不建议使用
        /// </summary>
        public UInt32 UnixTimeStamp
        {
            get { return (UInt32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds; }
        }

        public MainForm()
        {
            InitializeComponent();
            gmap.Load += InitMap;
            mapprovider.SelectedIndex = 0;
        }

        /// <summary>
        /// 设置 GMap 控件的初始属性，在控件载入时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void InitMap(object sender, EventArgs e)
        {
            //使用高德地图
            gmap.MapProvider = GMap.NET.MapProviders.AMapProvider.Instance;
            //缩放等级
            gmap.Zoom = 15;
            //支持绘制地标
            gmap.MarkersEnabled = true;
            //支持绘制多边形
            gmap.PolygonsEnabled = true;
            //右键拖动
            gmap.DragButton = MouseButtons.Right;
            //地图起始位置
            gmap.Position = Utility.StartPoint;
            //增加用于防止地标等标记的图层。
            gmap.Overlays.Add(overlayOne);
        }

        #region EVENT
        private void OnMainform_loaded(object sender, EventArgs e)
        {
            //将UI实例交给Drone，用于无人机自动更新数据，重绘UI使用
            Drone.Instance.UI = this;
            // 根据Utility内的变量设置自动更新的频率
            Drone.Instance.StartAutoRefresh(Utility.refresh_frequency);
            //将摄像机的空间交给Camera单例实例管理
            Camera.Instance.Init(videoSourcePlayer, combobox_cam);
            
            
        }

        /// <summary>
        /// 地图缩放时执行
        /// </summary>
        private void OnZoomChanged()
        {
            Console.WriteLine("Zoom  " + gmap.Zoom) ;
        }
        /// <summary>
        /// 此处用于记录鼠标左键的动作，绘制地标或矩形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            ///鼠标位置转化为经纬度
            downpoint = gmap.FromLocalToLatLng(e.X, e.Y);
            isMouseDown = true;
        }


        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;

            if (e.Button == MouseButtons.Left)
            {
               //得到矩形的另一个顶点
                uppoint = gmap.FromLocalToLatLng(e.X, e.Y);
                //下面代码在测试输出。
                if (bDraw)
                {
                    bDraw = false;
                }
                else
                {
                    
                    Console.WriteLine("MouseUp :({0},{1})", uppoint.Lat, uppoint.Lng);
                    //GMarkerGoogle marker = new GMarkerGoogle(uppoint, GMarkerGoogleType.green);
                    //overlayOne.Markers.Add(marker);
                }
            }
            isMouseDown = false;
        }

        /// <summary>
        /// 当鼠标移动且左键按下时，画框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            //cpoint为当前鼠标所指的经纬度坐标
            PointLatLng cpoint = gmap.FromLocalToLatLng(e.X, e.Y);
            mouse_lat.Text = cpoint.Lat.ToString();
            mouse_lng.Text = cpoint.Lng.ToString();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Control control = (Control)sender;
                if (isMouseDown)
                {
                    bDraw = true;
                    overlayOne.Polygons.Clear();
                    if (downpoint != null && cpoint != null)
                    {
                        List<PointLatLng> plist = new List<PointLatLng>();
                        //矩形的四个点
                        PointLatLng lt = downpoint;
                        PointLatLng lb = new PointLatLng(downpoint.Lat, cpoint.Lng);
                        PointLatLng rt = new PointLatLng(cpoint.Lat, downpoint.Lng);
                        PointLatLng rb = cpoint;
                        plist.Add(lt);
                        plist.Add(lb);
                        plist.Add(rb);
                        plist.Add(rt);
                        Range = plist;
                        GMapPolygon gmp = new GMapPolygon(plist, "Target");
                        control.Capture = false;
                        overlayOne.Polygons.Add(gmp);
                    }
                }

            }
        }


        #endregion EVENT

        #region METHOD
        /// <summary>
        /// UI数据应与Drone保持一致，该函数被Drone用来更新UI。不需直接调用
        /// </summary>
        /// <param name="type"></param>
        public void UpdateUI(DRONE_PROPERTY type)
        {
            switch (type)
            {
                case DRONE_PROPERTY.BATTERY:
                    label_battery.Text = Drone.Instance.Battery.ToString();
                    break;
                case DRONE_PROPERTY.LATITUDE:
                    label_latitude.Text = Drone.Instance.Latitude.ToString();
                    break;
                case DRONE_PROPERTY.LONGITUDE:
                    label_longitude.Text = Drone.Instance.Longitude.ToString();
                    break;
                case DRONE_PROPERTY.ALTITUDE:
                    label_hight.Text = Drone.Instance.Altitude.ToString();
                    break;
                case DRONE_PROPERTY.DIRECTION:
                    label_direction.Text = Drone.Instance.Direction.ToString();
                    break;
                case DRONE_PROPERTY.OTHER:
                    label_other.Text = Drone.Instance.Other.ToString();
                    break;
                case DRONE_PROPERTY.HORIZON:
                    label_horizon.Text = Drone.Instance.Horizon.ToString();
                    break;
                case DRONE_PROPERTY.SPEED:
                    label_speed.Text = Drone.Instance.Speed.ToString();
                    break;
            }
        }
        #endregion METHOD



        /// <summary>
        /// 程序关闭时，释放各种资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            Utility.CloseAllTasks();
            Camera.Instance.CloseCamera();
        }

        /// <summary>
        /// 打开或者关闭摄像头连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnconnect_Click(object sender, EventArgs e)
        {
            if(btnconnect.Text == "连接")
            {
                btnconnect.Text = "断开";
                Camera.Instance.ConnectCamera();
            }
            else
            {
                btnconnect.Text = "连接";
                Camera.Instance.CloseCamera();
            }
        }

        /// <summary>
        /// 打开或者关闭摄像头录制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnrecord_Click(object sender, EventArgs e)
        {
            if (btnrecord.Text == "开始录制")
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "video files (*.avi)|*.avi|All files (*.*)|*.*";
                    dialog.FilterIndex = 0;
                    dialog.RestoreDirectory = true;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        System.Diagnostics.Debug.WriteLine("Path " + dialog.FileName.ToString());
                        Camera.Instance.StartRecord(dialog.FileName.ToString());
                    }
                }

                btnrecord.Text = "停止录制";
            }
            else
            {
                btnrecord.Text = "开始录制";
                Camera.Instance.StopRecord();
            }
        }

        /// <summary>
        /// 摄像头输入源发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCamInputChanged(object sender, EventArgs e)
        {
            Camera.Instance.SetCamInputSrc(combobox_cam.SelectedIndex);
        }

        /// <summary>
        /// 清空地图上的各种标记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnclear_Click(object sender, EventArgs e)
        {
            overlayOne.Clear();
            if(homepoint != null)
            {
                GMarkerGoogle marker = new GMarkerGoogle(homepoint, GMarkerGoogleType.red);
                marker.ToolTipText = "Home";
                overlayOne.Markers.Add(marker);
            }
        }


        /// <summary>
        /// 将无人机置于地图中间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncenter_Click(object sender, EventArgs e)
        {
            gmap.Position = new PointLatLng(Drone.Instance.Latitude, Drone.Instance.Longitude);
        }
        /// <summary>
        /// 遍历开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnscan_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("移动", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Range != null && Pathes != null)
                {
                    try
                    {
                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                        btnconnect_Click(null,null);
                        btnrecord_Click(null,null);
                        stopwatch.Start();
                        for (int i = CurrentLocationIdx + 1; i < Pathes.Count; ++i)
                        {
                            Console.WriteLine("开始移动到 {0}/{1}", i,Pathes.Count);
                            //System.Threading.Thread.Sleep(2000);


                            await Drone.Instance.Move(Pathes[i], Utility.alt);
                            //if (timestamp.ContainsKey(i))
                            //    timestamp[i] = UnixTimeStamp;
                            //else
                            //    timestamp.Add(i,UnixTimeStamp);
                            Console.WriteLine("已经移动到 {0},{1}", i, stopwatch.ElapsedMilliseconds);
                            CurrentLocationIdx = i;
                        }
                        stopwatch.Stop();
                        btnrecord_Click(null, null);
                        btnconnect_Click(null, null);
                        CurrentLocationIdx = -1;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("btnscan_Click " + ex.Message);
                    }
                }
            }
            else
            {

            }
        }
        /// <summary>
        /// 生成路径点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnpath_Click(object sender, EventArgs e)
        {
            if (Range == null) return;
            Pathes = PathPlanner.MakePathPlan(new PointLatLng(Drone.Instance.Latitude, Drone.Instance.Longitude), Range, Utility.cam_width, Utility.cam_height);
            CurrentLocationIdx = -1;
            foreach (PointLatLng p in Pathes)
            {
                GMarkerGoogle marker = new GMarkerGoogle(p, GMarkerGoogleType.green);
                overlayOne.Markers.Add(marker);
            }
        }
        /// <summary>
        /// 选择物体图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnimg_Click(object sender, EventArgs e)
        {
            string filePath;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "";
            openFileDialog.Filter = "Image files (*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Choose Image File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                System.Diagnostics.Debug.WriteLine("File " + filePath);
            }
        }
        /// <summary>
        /// 确定遍历范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnrange_Click(object sender, EventArgs e)
        {
            MessageBox.Show("在地图上拖动即可");
        }
        /// <summary>
        /// 测试用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btntest1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Enabled = false;
            await Task.Run(() => {
                int i = 10;
                while(i-- > 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Task Tick .....");
                }
            });

            btn.Enabled = true;
        }
        /// <summary>
        /// 命令无人机飞回(若未通过MissionPlanner更改，初始为起飞点)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnback_Click(object sender, EventArgs e)
        {
            RPCClient.Instance.RPC.ReturnToLaunch();
        }

        /// <summary>
        /// 降落
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnlaunch_Click(object sender, EventArgs e)
        {
            RPCClient.Instance.RPC.LaunchManually();
        }
        /// <summary>
        /// 飞到下一个路径点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnnext_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始移动到 {0}", CurrentLocationIdx + 1);
            await Drone.Instance.Move(Pathes[CurrentLocationIdx + 1], 10);
            if (timestamp.ContainsKey(CurrentLocationIdx + 1))
                timestamp[CurrentLocationIdx + 1] = UnixTimeStamp;
            else
                timestamp.Add(CurrentLocationIdx + 1, UnixTimeStamp);
            Console.WriteLine("已经移动到 {0}", CurrentLocationIdx + 1);
            CurrentLocationIdx = CurrentLocationIdx + 1;
        }

        private void btnreconnect_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 更换地图源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapprovider_changed(object sender, EventArgs e)
        {
            if (mapprovider.SelectedIndex == 0)
            {
                gmap.MapProvider = GMap.NET.MapProviders.AMapProvider.Instance;

            }
            else
            {
                gmap.MapProvider = GMap.NET.MapProviders.AMapSateliteProvider.Instance;
            }
        }
        /// <summary>
        /// 手动缓存地图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncache_Click(object sender, EventArgs e)
        {

            RectLatLng area = gmap.ViewArea;
            if (!area.IsEmpty)
            {
                for (int i = (int)gmap.Zoom; i <= gmap.MaxZoom; i++)
                {
                    DialogResult res = MessageBox.Show("Ready ripp at Zoom = " + i + " ?", "GMap.NET", MessageBoxButtons.YesNoCancel);

                    if (res == DialogResult.Yes)
                    {
                        using (TilePrefetcher obj = new TilePrefetcher())
                        {
                            obj.Owner = this;
                            obj.ShowCompleteMessage = true;
                            obj.Start(area, i, gmap.MapProvider, 100, 5);
                        }
                    }
                    else if (res == DialogResult.No)
                    {
                        continue;
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Select map area holding ALT", "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
