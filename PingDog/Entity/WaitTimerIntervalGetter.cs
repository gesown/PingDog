using PingDog.Facade;
using System;

namespace PingDog.Interface
{
    internal class WaitTimerIntervalGetter : IWaitTimerIntervalGetter
    {
        public double GetWaitTimerInterval()
        {
            return PDFacade.GetPDModel().WaitDelay;
        }
    }
}