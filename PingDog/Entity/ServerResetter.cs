using PingDog.Facade;
using System;
using PingDog.Model;
using Realterm;
using PInvokeSerialPort;

namespace PingDog.Interface
{
    internal class ServerResetter : IServerResetter
    {
        private IPDModel model;
        private SerialPort serialPort;

        //     private IRealtermIntf terminal;

        public string[] names { get; private set; }

        public void ResetServer(bool reset)
        {

            //  terminal = PDFacade.GetTerminal();

            model = PDFacade.GetPDModel();
             names = model.PortNames;
            Console.WriteLine();
            Console.WriteLine("Ports: ");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            if (model.Debug) Console.Write(" Reset? " + reset);
            try
            {
                Console.Write(" Port Name: "+model.PortName);
                serialPort = new SerialPort(model.PortName);
                serialPort.UseRts = HsOutput.Online;
                if (reset) { serialPort.Open(); } else { serialPort.Close(); }
            //    terminal.Port = model.PortName;
           //     terminal.PortOpen = true;
             //   if (model.Debug) Console.Write(" RTS Before: " + terminal.RTS);
            //    terminal.RTS = reset; // true kills power to server
              //  if (model.Debug) Console.Write(" RTS After: " + terminal.RTS);
            }
            catch (Exception ex)
            {
                Console.Write("Reset Server Error: " + ex.Message);
            }
        }
    }
}