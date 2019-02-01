using PingDog.Facade;
using PingDog.Interface;
using System;

namespace PingDog.Entity
{
    internal class CheckTimerIntervalGetter : ICheckTimerIntervalGetter
    {
        public double GetCheckTimerInterval()
        {
            return PDFacade.GetPDModel().CheckDelay;
        }
    }
}