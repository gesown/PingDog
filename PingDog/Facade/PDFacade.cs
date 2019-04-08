using PingDog.Model;
using PingDog.Interface;
using PingDog.Entity;
using PingDog.Factory;
using System.Collections.Generic;
using Realterm;

namespace PingDog.Facade
{
    public static class PDFacade
    {
        private static PDModel _PDModel;
        private static PDFactory _PDFactory;

        public static bool IsServerOn { get; internal set; }

        internal static bool RunWatchDog()
        {
            IWatchDogRunner wdr = new WatchDogRunner();
            return wdr.RunWatchDog();
        }

        internal static bool GetDebugMode()
        {
            IDebugModeGetter tmg = new DebugModeGetter();
            return tmg.GetDebugMode();
        }

        internal static IRealtermIntf GetTerminal()
        {
            if (_PDFactory == null)
            {
                _PDFactory = new PDFactory();
            }
            return _PDFactory.RealTerminal;
        }

        internal static string GetIpToPing()
        {
            IIpToPingGetter tmg = new IpToPingGetter();
            return tmg.GetIpToPing();
        }

        internal static IEnumerable<string> GetPortNames()
        {
            IPortNamesGetter png = new PortNamesGetter();
            return png.GetPortNames();
        }

        internal static int GetPortIndex()
        {
            IPortIndexGetter pig = new PortIndexGetter();
            return pig.GetPortIndex();
        }

        internal static string GetPortName()
        {
            IPortNameGetter tmg = new PortNameGetter();
            return tmg.GetPortName();
        }

        internal static IPDModel GetPDModel()
        {
            if (_PDModel == null)
            {
                _PDModel = new PDModel();
            }
            return _PDModel;
        }

        internal static void ResetServer(bool reset)
        {
            IServerResetter sr = new ServerResetter();
            sr.ResetServer(reset);
        }

        internal static PInvokeSerialPort.SerialPort GetSerialPort()
        {
            ISerialPortGetter spg = new SerialPortGetter();
            return spg.GetSerialPort();
        }

        internal static bool GetTestMode()
        {
            ITestModeGetter tmg = new TestModeGetter();
            return tmg.GetTestMode();
        }

        internal static double GetCheckTimerInterval()
        {
            ICheckTimerIntervalGetter ctg = new CheckTimerIntervalGetter();
            return ctg.GetCheckTimerInterval();
        }

        internal static double GetWaitTimerInterval()
        {
            IWaitTimerIntervalGetter ctg = new WaitTimerIntervalGetter();
            return ctg.GetWaitTimerInterval();
        }

        public static bool GetServiceMode()
        {
            IServiceModeGetter tmg = new ServiceModeGetter();
            return tmg.GetServiceMode();
        }
    }
}