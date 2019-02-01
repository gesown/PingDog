using PingDog.Interface;
using PingDog.Facade;

namespace PingDog.Entity
{
    internal class TestModeGetter : ITestModeGetter
    {
        public bool GetTestMode()
        {
            return PDFacade.GetPDModel().TestMode;
        }
    }
}