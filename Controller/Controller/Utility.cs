using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using GMap.NET;
namespace Controller
{
    static class Utility
    {
        /// <summary>
        /// 飞行高度
        /// </summary>
        public static double alt = 5.0;
        /// <summary>
        /// 摄像机的宽
        /// </summary>
        public static double cam_width = 10;
        /// <summary>
        /// 摄像机的高
        /// </summary>
        public static double cam_height = 10;

        /// <summary>
        /// 无人机跟新数据的频率
        /// </summary>
        public static int refresh_frequency = 200;
        /// <summary>
        /// 无人机与目标之间的距离误差容忍度
        /// </summary>
        public static double dis_toleration = 5;
        /// <summary>
        /// 无人机飞行时检查与目标之间的距离的频率
        /// </summary>
        public static int dis_detect_frequcncy = 500;
        /// <summary>
        /// 手动设置的地图起始中心点。
        /// </summary>
        public static GMap.NET.PointLatLng StartPoint = new GMap.NET.PointLatLng(30.26580024223, 120.119568733032);

        static Dictionary<string, Timer> timers = new Dictionary<string, Timer>();
        static double radius_of_earth = 6378100.0;
        /// <summary>
        /// 创建制定周期，制定处理事件的定时任务
        /// </summary>
        /// <param name="interval">间隔事件的周期 ms</param>
        /// <param name="handler">用来指定的动作</param>
        public static void CreateTask(string name, double interval, ElapsedEventHandler handler)
        {
            Timer t = new Timer(interval);
            timers.Add(name, t);
            t.Elapsed += handler;
            //周期执行
            t.AutoReset = true;
            t.Enabled = true;
        }
        /// <summary>
        /// 关闭指定的定时任务
        /// </summary>
        /// <param name="name"></param>
        public static void CloseTask(string name)
        {
            if (timers.ContainsKey(name))
            {
                timers[name].Close();
            }
        }
        /// <summary>
        /// 关闭所有的定时任务
        /// </summary>
        public static void CloseAllTasks()
        {
            foreach(Timer t in timers.Values)
            {
                t.Close();
            }
        }
        /// <summary>
        /// 将角度转化为弧度
        /// </summary>
        /// <param name="degrees">角度</param>
        /// <returns>弧度</returns>
        public static double Radians(double degrees)
        {
            return Math.PI * degrees / 180.0 ;
        }
        /// <summary>
        /// 计算以经纬度表示的两个点的距离
        /// </summary>
        /// <param name="p1">点1</param>
        /// <param name="p2">点2</param>
        /// <returns>距离</returns>
        public static double CalGPSDistance(PointLatLng p1, PointLatLng p2)
        {
            double lat1 = Radians(p1.Lat);
            double lng1 = Radians(p1.Lng);
            double lat2 = Radians(p2.Lat);
            double lng2 = Radians(p2.Lng);

            double dLat = lat2 - lat1;
            double dLng = lng2 - lng1;

            double tmp = Math.Pow( Math.Sin(0.5 * dLat), 2) + 
                         Math.Pow(Math.Sin(0.5 * dLng) , 2) * Math.Cos(lat1) * Math.Cos(lat2);
            double dis = 2.0 * Math.Atan2(Math.Sqrt(tmp), Math.Sqrt(1- tmp));

            return dis * radius_of_earth;
        }

        /// <summary>
        /// 计算简单的欧氏距离
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static double CalEuclideanDistance(double x1, double y1, double x2 = 0, double y2 = 0)
        {
            return  Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2,2));
        }

        /// <summary>
        /// 计算旋转角
        /// </summary>
        /// <param name="old_vx"></param>
        /// <param name="old_vy"></param>
        /// <param name="new_vx"></param>
        /// <param name="new_vy"></param>
        /// <returns></returns>
        public static double CalRotateAngle(double old_vx, double old_vy,
                                            double new_vx, double new_vy)
        {
            double dis = Math.Acos(  (old_vx * new_vx + old_vy * new_vy) / 
                                    (CalEuclideanDistance(old_vx, old_vy) * CalEuclideanDistance(new_vx, new_vy))
                                    );
            return dis;
        }


        /// <summary>
        /// //预先判断目标端口是否可达
        /// </summary>
        /// <param name="serveraddr"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool isReachable(string serveraddr, int port)
        {
            
            System.Net.Sockets.TcpClient tcpClient = new System.Net.Sockets.TcpClient();

            try
            {
                tcpClient.Connect(serveraddr, port);
                tcpClient.Close();
                return true;
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("{0}:{1} Port is unreachable", serveraddr, port);
                return false;
            }
        }
    }
}
