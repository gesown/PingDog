using PingDog.Facade;
using System;
using PingDog.Model;

namespace PingDog.Interface
{
    internal class ServerResetter : IServerResetter
    {
        private IPDModel model;

        public bool Debug { get { return PDFacade.GetDebugMode(); } }

        public bool TestMode { get { return PDFacade.GetTestMode(); } }

        public void ResetServer(bool reset)
        {
           var  serialPort = PDFacade.GetSerialPort();
            if (TestMode || Debug)
            {
                Console.WriteLine();
                Console.WriteLine(" Reset? " + reset);
            }
            try
            {
                if (reset)
                {
                    serialPort.Close();
                    PDFacade.IsServerOn = false;
                }
                else
                {
                    if (!serialPort.Online||!PDFacade.IsServerOn)
                    {
                        PDFacade.IsServerOn = serialPort.Open(); // Port open removes server power by clearing RTS
                        if (!PDFacade.IsServerOn) { throw new Exception("Port Not Available"); }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reset Server Error: " + ex.Message);                
            }
        }
    }
}