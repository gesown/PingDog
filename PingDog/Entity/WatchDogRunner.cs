using PingDog.Interface;
using System.Net.NetworkInformation;
using PingDog.Facade;
using System;

namespace PingDog.Entity
{
    internal class WatchDogRunner : IWatchDogRunner
    {
        public bool RunWatchDog()
        {
            {
                bool pingable = false;
                Ping pinger = new Ping();
                var model = PDFacade.GetPDModel();
                try
                {
                    PingReply reply = pinger.Send(model.IpAddress);
                    pingable = reply.Status == IPStatus.Success;
                }
                catch (PingException ex)
                {
                    Console.Write(" ping error: " + ex.Message);
                    var exM = ex.Message;
                }
                finally
                {
                    if (pinger != null)
                    {
                        pinger.Dispose();
                    }
                }
                Console.Write(" p ");
                return pingable;
            }
        }
    }
}
