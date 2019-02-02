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
                    Console.WriteLine();
                    Console.WriteLine(" ping error: " + ex.Message);
                    Console.WriteLine();
                    if (!PDFacade.IsServerOn)
                    {
                        PDFacade.ResetServer(false);
                        PDFacade.IsServerOn = true;
                        Console.WriteLine();
                        Console.WriteLine("Server Initial Power On.");
                        Console.WriteLine();
                    }
                }
                finally
                {
                    if (pinger != null)
                    {
                        pinger.Dispose();
                    }
                }
                Console.WriteLine(" ping ");
                return pingable;
            }
        }
    }
}
