using System;
using PingDog.Interface;
using PingDog.Facade;

namespace PingDog.Entity
{
    internal class PortIndexGetter : IPortIndexGetter
    {
        public int GetPortIndex()
        {
            return PDFacade.GetPDModel().PortIndex;
        }
    }
}