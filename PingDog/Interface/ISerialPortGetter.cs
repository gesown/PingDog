using System.IO.Ports;

namespace PingDog.Interface
{
    internal interface ISerialPortGetter
    {
        PInvokeSerialPort.SerialPort GetSerialPort();
    }
}