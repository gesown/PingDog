using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingDog.Model
{
    internal class PDModel : IPDModel
    {
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
                return SerialPort.GetPortNames();
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
