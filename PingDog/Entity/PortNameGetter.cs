using PingDog.Interface;
using PingDog.Facade;

namespace PingDog.Entity
{
    internal class PortNameGetter : IPortNameGetter
    {
        public string GetPortName()
        {
            return PDFacade.GetPDModel().PortName;
        }
    }
}