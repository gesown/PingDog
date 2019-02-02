using System.Collections.Generic;
using PingDog.Interface;
using PingDog.Facade;
using PingDog.Model;

namespace PingDog.Entity
{
    internal class PortNamesGetter : IPortNamesGetter
    {
        public IEnumerable<string> GetPortNames()
        {
            IPDModel model = PDFacade.GetPDModel();
            return  model.PortNames;
        }
    }
}