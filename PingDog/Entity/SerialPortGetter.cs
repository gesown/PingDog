using PingDog.Facade;
using PingDog.Model;
using System;
using System.IO.Ports;
using PInvokeSerialPort;

namespace PingDog.Interface
{
    internal class SerialPortGetter : ISerialPortGetter
    {
        PInvokeSerialPort.SerialPort ISerialPortGetter.GetSerialPort()
        {
            return PDFacade.GetPDModel().PISerialPort;
        }
    }
}