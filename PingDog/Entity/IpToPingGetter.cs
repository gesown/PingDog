using System;
using PingDog.Interface;
using PingDog.Facade;

namespace PingDog.Entity
{
    internal class IpToPingGetter : IIpToPingGetter
    {
        public string GetIpToPing()
        {
            return PDFacade.GetPDModel().IpAddress;
        }
    }
}