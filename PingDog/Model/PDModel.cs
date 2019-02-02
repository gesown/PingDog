using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PInvokeSerialPort;

namespace PingDog.Model
{
    internal class PDModel : IPDModel
    {
        private static PInvokeSerialPort.SerialPort _PISerialPort;

        public double CheckDelay
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["CheckDelay"]);
            }
        }

        public bool Debug
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["Debug"]);
            }
        }

        public string IpAddress
        {
            get
            {
                return ConfigurationManager.AppSettings["IpAddress"];
            }
        }

        public PInvokeSerialPort.SerialPort PISerialPort
        {
            get
            {
                if (_PISerialPort==null)
                {
                    _PISerialPort = new PInvokeSerialPort.SerialPort(PortName);
                    _PISerialPort.UseRts = HsOutput.Online;

                }
                return _PISerialPort;
            }
        }

        public int PortIndex
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["PortIndex"]);
            }
        }

        public string PortName
        {
            get
            {
                return PortNames[PortIndex];
            }
        }

        public string[] PortNames
        {
            get
            {
                return System.IO.Ports.SerialPort.GetPortNames();
            }
        }

        public bool TestMode
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["TestMode"]);
            }
        }

        public double WaitDelay
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["WaitDelay"]);
            }
        }
    }
}
