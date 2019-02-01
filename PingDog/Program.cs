using System;
using System.Timers;
using PingDog.Interface;
using PingDog.Facade;
using PingDog.Model;

namespace PingDog
{
    /// <summary>
    /// ModulePort - Serial port for connection to reset module
    /// PingPort - IP of monitored system
    /// Usage: PingDog {ModulePort} {PingPort}
    /// </summary>
    class Program
    {
        public static Timer checkTimer = new Timer();
        public static Timer waitTimer = new Timer();
        private static IPDModel model;

        public static bool TestMode { get { return PDFacade.GetTestMode(); } }
        public static double CheckTimerInterval { get { return PDFacade.GetCheckTimerInterval(); } }
        public static double WaitTimerInterval { get { return PDFacade.GetWaitTimerInterval(); } }

        static void Main(string[] args)
        {
            InitializeTimers();
             model = PDFacade.GetPDModel();
            Console.Read();
        }

        private static void InitializeTimers()
        {
            checkTimer.Interval = CheckTimerInterval;
            checkTimer.Elapsed += CheckTimer_Elapsed;
            waitTimer.Interval = WaitTimerInterval;
            waitTimer.Elapsed += WaitTimer_Elapsed;
            checkTimer.Enabled = true;
        }

        private static void WaitTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
          if(model.Debug)  Console.Write("  Waiting");
            waitTimer.Enabled = false;
            PDFacade.ResetServer(false);
            checkTimer.Enabled = true;
        }

        private static void CheckTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (model.Debug) Console.Write("  Checking");
            checkTimer.Enabled = false;
            var pingResult = PDFacade.RunWatchDog();
            if (model.Debug) Console.Write("  Ping Ok: "+pingResult.ToString());
            if (!TestMode && !pingResult || TestMode)
            {
                PDFacade.ResetServer(true);
            }
            waitTimer.Enabled = true;
        }
    }
}
