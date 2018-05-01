using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusInfo
{
    public interface IWebRequestProvider
    {
        Task<T> GetBusRoutesAsync<T>(string url);
    }
}
