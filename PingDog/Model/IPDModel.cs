using PInvokeSerialPort;

namespace PingDog.Model
{
    internal interface IPDModel
    {
        string[] PortNames { get; }
        int PortIndex { get;  }
        string PortName { get; }
        string IpAddress { get;  }
        double CheckDelay { get;  }
        double WaitDelay { get;  }
        bool TestMode { get;  }
        bool Debug { get; }
        SerialPort PISerialPort { get;  }
    }
}