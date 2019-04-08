namespace PingDog.Facade
{
    public class ServiceModeGetter : IServiceModeGetter
    {
        public bool GetServiceMode()
        {
            return PDFacade.GetPDModel().ServiceMode;
        }
    }
}