using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace BusInfo.Web
{
    public class BusRouteProvider : IWebRequestProvider
    {
        public async Task<T> GetBusRoutesAsync<T>(string url)
        {
            WebRequest request = WebRequest.CreateHttp(url);
            var results = await request.GetResponseAsync();
            var response = results.GetResponseStream();
            var sr = new StreamReader(response);
            var json = await sr.ReadToEndAsync();
            var routes = JsonConvert.DeserializeObject<T>(json);
            return routes;
        }
    }
}
