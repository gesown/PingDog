using System.IO.Ports;

namespace PingDog.Interface
{
    internal interface ISerialPortGetter
    {
        SerialPort GetSerialPort();
    }
}