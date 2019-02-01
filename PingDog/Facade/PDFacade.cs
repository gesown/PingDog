using System.IO.Ports;
using PingDog.Model;
using PingDog.Interface;
using PingDog.Entity;
using System;
using PingDog.Factory;
using Realterm;

namespace PingDog.Facade
{
    public static class PDFacade
    {
        private static PDModel _PDModel;
        private static PDFactory _PDFactory;

        internal static bool RunWatchDog()
        {
            IWatchDogRunner wdr = new WatchDogRunner();
            return wdr.RunWatchDog();
        }

        internal static IRealtermIntf GetTerminal()
        {
            if (_PDFactory == null)
            {
                _PDFactory = new PDFactory();
            }
            return _PDFactory.RealTerminal;
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

        internal static SerialPort GetSerialPort()
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
    }
}