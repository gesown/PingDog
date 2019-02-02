using PingDog.Facade;
using PingDog.Interface;

namespace PingDog.Entity
{
    internal class DebugModeGetter : IDebugModeGetter
    {
        public bool GetDebugMode()
        {
            return PDFacade.GetPDModel().Debug;
        }
    }
}