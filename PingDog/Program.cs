using System;
using System.Collections.Generic;
using System.Timers;
using PingDog.Facade;
using PingDog.Model;
using Threading = System.Threading;

namespace PingDog
{
    class Program
    {
        public static Timer checkTimer = new Timer();
        public static Timer waitTimer = new Timer();
        private static IPDModel model;

        public static bool TestMode { get { return PDFacade.GetTestMode(); } }
        public static bool Debug { get { return PDFacade.GetDebugMode(); } }
        public static double CheckTimerInterval { get { return PDFacade.GetCheckTimerInterval(); } } // Time to wait for ping response
        public static double WaitTimerInterval { get { return PDFacade.GetWaitTimerInterval(); } } // Time to wait between pings and for server reset
        public static string IpToPing { get { return PDFacade.GetIpToPing(); } }

        public static string PortName { get { return PDFacade.GetPortName(); } }

        public static IEnumerable<string> PortNames { get { return PDFacade.GetPortNames(); } }

        public static int PortIndex { get { return PDFacade.GetPortIndex(); } }

        static void Main(string[] args)
        {
            Console.WriteLine(" Debug Mode: " + Debug);
            Console.WriteLine(" Test Mode: " + TestMode);
            Console.WriteLine(" Check Timer Interval: " + CheckTimerInterval);
            Console.WriteLine(" Wait Timer Interval: " + WaitTimerInterval);
            Console.WriteLine(" Ip To Ping: " + IpToPing);
            Console.WriteLine(" Serial Ports Available: ");
            foreach (var portname in PortNames)
            {
                Console.WriteLine(portname);
            }
            Console.WriteLine(" Serial Port Name Index: " + PortIndex);
            Console.WriteLine(" Serial Port Name: " + PortName);
            InitializeTimers();
            Console.WriteLine("Hit Any Key to Exit.");
            Threading.Thread.Sleep(1000);
            PDFacade.ResetServer(false);
            if (!PDFacade.IsServerOn) { DisableTimers(); }
            Console.Read();
        }

        private static void DisableTimers()
        {
            checkTimer.Enabled = false;
            waitTimer.Enabled = false;
        }

        private static void InitializeTimers()
        {
            checkTimer.Interval = CheckTimerInterval;
            checkTimer.Elapsed += CheckTimer_Elapsed;
            waitTimer.Interval = WaitTimerInterval;
            waitTimer.Elapsed += WaitTimer_Elapsed;
            checkTimer.Enabled = true;
        }

        private static void WaitTimer_Elapsed(object sender, ElapsedEventArgs e) // Time to resume ping after server power cycle or recheck after delay
        {
            waitTimer.Enabled = false;
            checkTimer.Enabled = true;
        }

        private static void CheckTimer_Elapsed(object sender, ElapsedEventArgs e) // Ping server
        {
            if (Debug) Console.WriteLine("  Pinging..  ");
            checkTimer.Enabled = false;
            var pingResult = PDFacade.RunWatchDog();
            if (Debug) Console.WriteLine("  Ping Ok? " + pingResult.ToString());
            if (!TestMode && !pingResult || TestMode) // Always resets server if in test mode or ping fails
            {
                if (PDFacade.IsServerOn) { PDFacade.ResetServer(true); }// Cut power to server
                if (Debug) Console.WriteLine("  Server Power Off ");
                Threading.Thread.Sleep(1000); // Wait for server to power down
                if (!PDFacade.IsServerOn) { PDFacade.ResetServer(false); } // Power on to server
                if (Debug) Console.WriteLine("  Server Power On ");
            }
            waitTimer.Enabled = true; // Delay check until server resets or time to ping again
        }
    }
}
