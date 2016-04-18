using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
namespace Controller
{
    /// <summary>
    /// 该类用于生成巡航路径
    /// </summary>
    public static class PathPlanner
    {
        /// <summary>
        /// 将转化后矩形内的点，映射到经纬度坐标上
        /// </summary>
        /// <returns></returns>
        public static PointLatLng ConvertBack2PointLatLng(double x, double y, double rotateangle, double scale, PointLatLng v0)
        {
            PointLatLng point = new PointLatLng();
            point.Lng = x * Math.Cos(rotateangle) + y * Math.Sin(rotateangle);
            point.Lat = x * Math.Sin(rotateangle) - y * Math.Cos(rotateangle);
            point.Lng =  point.Lng / scale + v0.Lng;
            point.Lat = point.Lat / scale + v0.Lat;
            return point;
        }
       
        
        /// <summary>
        /// 生成路径点
        /// </summary>
        /// <param name="current">无人机当前点 </param>
        /// <param name="vertexes">待巡航范围的顶点集合，目前应该是矩形的四个顶点</param>
        /// <param name="width">摄像机的画面宽度</param>
        /// <param name="height">摄像机的画面高度</param>
        /// <returns></returns>
        public static List<PointLatLng> MakePathPlan(PointLatLng current, List<PointLatLng> vertexes, double width, double height)
        {
            List<PointLatLng> path = new List<PointLatLng>();
            int startidx = 0;
            double dis = double.MaxValue;
            //选一个最近的点作为起始
            for(int i = 0; i < vertexes.Count; i++)
            {
                if(Utility.CalGPSDistance(current, vertexes[i]) < dis)
                {
                    startidx = i;
                    dis = Utility.CalGPSDistance(current, vertexes[i]);
                }
            }
            ///将起始点作为左下角的点，制作一个矩形，
            ///  3-----------2
            ///  |           |
            ///  |           |
            ///  |           |
            ///  0-----------1
            List<int> vertexMap = new List<int>() { 0,0,0,0};
            for(int i = 0; i < 4; i++)
            {
                vertexMap[i] = (startidx + i) % 4;
            }

            double dis01 = Utility.CalGPSDistance(vertexes[vertexMap[0]], vertexes[vertexMap[1]]);
            double dis03 = Utility.CalGPSDistance(vertexes[vertexMap[0]], vertexes[vertexMap[3]]);
            double rotateangle = Utility.CalRotateAngle(vertexes[vertexMap[1]].Lng - vertexes[vertexMap[0]].Lng, vertexes[vertexMap[1]].Lat - vertexes[vertexMap[0]].Lat,
                                    dis01, 0);
            double scale = dis01 / Utility.CalEuclideanDistance(vertexes[vertexMap[0]].Lng, vertexes[vertexMap[0]].Lat,
                                                                vertexes[vertexMap[1]].Lng, vertexes[vertexMap[1]].Lat);
            bool flag = false;
            for (double x = width / 2; x < dis01; x += width)
                //for (double x = width / 2; x < dis01 - width / 2; x += width)
            {

                if (!flag)
                {
                    for (double y = height / 2; y < dis03 - height / 2; y += height)
                    {
                        PointLatLng p = ConvertBack2PointLatLng(x, y, rotateangle, scale, vertexes[vertexMap[0]]);
                        path.Add(p);
                    }
                }
                else
                {
                    for (double y = dis03 - height / 2; y > height / 2; y -= height)
                    {
                        PointLatLng p = ConvertBack2PointLatLng(x, y, rotateangle, scale, vertexes[vertexMap[0]]);
                        path.Add(p);
                    }
                }
                flag = !flag;
            }
            return path;
        }


    }
}
