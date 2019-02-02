using System.Collections.Generic;

namespace PingDog.Interface
{
    internal interface IPortNamesGetter
    {
        IEnumerable<string> GetPortNames();
    }
}