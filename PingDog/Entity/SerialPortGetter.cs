using PingDog.Facade;
using PingDog.Model;
using System;
using System.IO.Ports;

namespace PingDog.Interface
{
    internal class SerialPortGetter : ISerialPortGetter
    {
        public SerialPort GetSerialPort()
        {
            IPDModel model = PDFacade.GetPDModel();
            return new SerialPort(model.PortNames[model.PortIndex]);
        }
    }
}