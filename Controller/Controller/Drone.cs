using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;

namespace Controller
{
    /// <summary>
    /// 无人机属性
    /// </summary>
    public enum DRONE_PROPERTY
    {
        LONGITUDE,
        LATITUDE,
        SPEED,
        ALTITUDE,
        HORIZON,
        DIRECTION,
        BATTERY,
        OTHER
    }
    class Drone
    {
        #region INSTANCE
        /// <summary>
        /// 静态单例
        /// </summary>
        private static Drone _instance = null;
        /// <summary>
        /// 用于单例模式的同步检测
        /// </summary>
        private static readonly object SynObject = new object();
        /// <summary>
        /// 私有构造
        /// </summary>
        private Drone() {
            _latitude = 0;
            _longitude = 0;
            _speed = 0;
            _altitude = 0;
            _battery = 0;
            _direction = 0;
            _horizon = 0;
            _other = 0;
        }

        /// <summary>
        /// 获得该类的单例
        /// </summary>
        public static Drone Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (SynObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new Drone();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion INSTANCE

        #region PRIVATE　VARIABLES
        /// <summary>
        /// 主窗口UI实例
        /// </summary>
        private MainForm _ui;
        /// <summary>
        /// 纬度
        /// </summary>
        private double _latitude;
        /// <summary>
        /// 经度
        /// </summary>
        private double _longitude;

        private double _speed;
        private double _altitude;
        private double _battery;
        private double _direction;
        private double _horizon;
        private double _other;
        private bool _isbusy;
        private PointLatLng _destination;
        #endregion PRIVATE VARIABLES

        #region PUBLIC ATTRIBUTE
        /// <summary>
        /// 无人机是否忙碌
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return _isbusy;
            }
            set
            {
                _isbusy = value;
            }
        }
        /// <summary>
        /// 无人机的目的地
        /// </summary>
        public PointLatLng Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }

        /// <summary>
        /// MainForm的引用，用来更新UI元素
        /// </summary>
        public MainForm UI
        {
            get { return _ui; }
            set { _ui = value; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value;UI.UpdateUI(DRONE_PROPERTY.LONGITUDE); }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; UI.UpdateUI(DRONE_PROPERTY.LATITUDE); }
        }

        /// <summary>
        /// 将经纬度封装为 GMap 可以直接接受的属性
        /// </summary>
        public PointLatLng Position
        {
            get { return new PointLatLng(_latitude, _longitude); }
        }
        /// <summary>
        /// 速度
        /// </summary>
        public double Speed
        {
            get { return _speed; }
            set { _speed = value; UI.UpdateUI(DRONE_PROPERTY.SPEED); }
        }
        /// <summary>
        /// 高度
        /// </summary>
        public double Altitude
        {
            get { return _altitude; }
            set { _altitude = value; UI.UpdateUI(DRONE_PROPERTY.ALTITUDE); }
        }
        /// <summary>
        /// 方向
        /// </summary>
        public double Direction
        {
            get { return _direction; }
            set { _direction = value; UI.UpdateUI(DRONE_PROPERTY.DIRECTION); }
        }
        /// <summary>
        /// 水平
        /// </summary>
        public double Horizon
        {
            get { return _horizon; }
            set { _horizon = value; UI.UpdateUI(DRONE_PROPERTY.HORIZON); }
        }
        /// <summary>
        /// 电量，0-1之间
        /// </summary>
        public double Battery
        {
            get { return _battery; }
            set { _battery = value; UI.UpdateUI(DRONE_PROPERTY.BATTERY); }
        }
        /// <summary>
        /// 未定，其他信息
        /// </summary>
        public double Other
        {
            get { return _other; }
            set { _other = value; UI.UpdateUI(DRONE_PROPERTY.OTHER); }
        }
        
        #endregion PUBLIC ATTRIBUTE

        #region METHOD

        /// <summary>
        /// 开启自动更新
        /// </summary>
        /// <param name="time">自动更新的频率 /ms</param>
        public void StartAutoRefresh(double time)
        {
            Utility.CreateTask("AutoRefresh", time, AutoRefresh);
        }

        /// <summary>
        /// 与MissionPlanner通信，定时更新任务
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void AutoRefresh(object source, System.Timers.ElapsedEventArgs e)
        {
            ///默认的MissionPlanner监听脚本的本机地址
            if (!Utility.isReachable("127.0.0.1", 8080)){
                System.Diagnostics.Debug.WriteLine("链接失败 MissionPlanner 服务器未打开");

                return;
            }
            ///涉及UI更新，委托给UI线程执行
            Action AsyncUIDelegate = delegate () {
                try
                {
                    Longitude = RPCClient.Instance.RPC.GetLng();
                    Latitude = RPCClient.Instance.RPC.GetLat();
                    Altitude = RPCClient.Instance.RPC.GetAlt();
                    Battery = RPCClient.Instance.RPC.GetVoltage();
                    Speed = RPCClient.Instance.RPC.GetGroundSpeed();
                    System.Diagnostics.Debug.WriteLine("更新数据");

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("AutoRefresh " + ex.Message);
                }
            };
            UI.Invoke(AsyncUIDelegate);
        }
        /// <summary>
        /// 暂未使用，可以考虑将所有更新动作封装此处
        /// </summary>
        private void doRefresh()
        {
            try
            {
                Longitude = RPCClient.Instance.RPC.GetLng();
                Latitude = RPCClient.Instance.RPC.GetLat();
                Altitude = RPCClient.Instance.RPC.GetAlt();
                Battery = RPCClient.Instance.RPC.GetVoltage();
                Speed = RPCClient.Instance.RPC.GetGroundSpeed();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("AutoRefresh " + ex.Message);
            }
        }

        /// <summary>
        /// 以指定的高度，移动到给定经纬度所指示的目的地。
        /// </summary>
        /// <param name="des">目的地</param>
        /// <param name="alt">高度</param>
        /// <returns></returns>
        public async Task Move(PointLatLng des, double alt)
        {
            RPCClient.Instance.RPC.SetWP(des.Lat, des.Lng, alt);
            Destination = des;
            await Task.Run(() =>
            {
                double dis = Utility.CalGPSDistance(des, Position);
                while (dis > Utility.dis_toleration)
                {
                    System.Diagnostics.Debug.WriteLine("Distance {0}", dis);
                    System.Threading.Thread.Sleep(Utility.dis_detect_frequcncy);
                }
            });

        }

        #endregion METHOD

    }
}
