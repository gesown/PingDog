using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Timers;
using System.IO.Ports;
using System.Threading;
using System.Configuration;
namespace SerialPortBase
{
    class Program
    {
        static void Main(string[] args)
        {
            var portNames = SerialPort.GetPortNames();
            SerialPort port = new SerialPort(portNames[0],300);
            if (!port.IsOpen){ port.Open(); }
            do
            {
                port.Write("Test This Test ThisTest ThisTest ThisTest ThisTest ThisTest ThisTest ThisTest ThisTest ThisTest ThisTest ThisTest ThisTest ThisTest ThisTest This");
                Console.Write(".");
            } while (true);
        }
    }
}
