using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookComputing.XmlRpc;
namespace Controller
{
    [XmlRpcUrl("http://127.0.0.1:8080")]
    public interface Proxy : IXmlRpcProxy
    {
        [XmlRpcMethod]
        void Test();
        [XmlRpcMethod]
        double GetLat();
        [XmlRpcMethod]
        double GetLng();
        [XmlRpcMethod]
        double GetGroundSpeed();
        [XmlRpcMethod]
        string GetMode();
        [XmlRpcMethod]
        void ChangeMode(string mode);
        [XmlRpcMethod]
        void SetWP(double lat, double lng, double alt);
        [XmlRpcMethod]
        double GetVoltage();
        [XmlRpcMethod]
        double GetBatteryRemaining();
        [XmlRpcMethod]
        double GetAlt();
        [XmlRpcMethod]
        double GetRoll();
        [XmlRpcMethod]
        void Clear();
        [XmlRpcMethod]
        void ReturnToLaunch();
        [XmlRpcMethod]
        void LaunchManually();
    }

    /// <summary>
    /// 用来控制远程调用的客户端代理
    /// </summary>
    class RPCClient
    {
        /// <summary>
        /// 静态单例
        /// </summary>
        private static RPCClient _instance = null;
        /// <summary>
        /// 用于单例模式的同步检测
        /// </summary>
        private static readonly object SynObject = new object();
        /// <summary>
        /// 私有构造
        /// </summary>
        private RPCClient()
        {
            _proxy = XmlRpcProxyGen.Create<Proxy>();
            
        }

        private Proxy _proxy = null;
        /// <summary>
        /// 获得该类的单例
        /// </summary>
        public static RPCClient Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (SynObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new RPCClient();
                        }
                    }
                }
                return _instance;
            }
        }

        public Proxy RPC
        {
            get { return _proxy; }
        }


    }
}
