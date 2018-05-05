using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BusInfo.Web.Pages
{
    public class DisplayRouteData
    {
        public string Description { get; set; }
        public string ShortName { get; set; }
        public DateTime PredictedArrival { get; set; }
        public string DisplayArrivalTime
        {
            get
            {
                return this.PredictedArrival.ToShortTimeString();
            }
        }
    }

    public class IndexModel : PageModel
    {
        private IWebRequestProvider _busRouteProvider;

        public IEnumerable<DisplayRouteData> Routes { get; private set; }

        public IndexModel(IWebRequestProvider routeProvider)
        {
            _busRouteProvider = routeProvider;
        }

        public async Task OnGetAsync()
        {
            const string routeServiceURL = "http://localhost:5000/api/routes"; //"http://businfo.api/api/routes";
            List<Route> routes = await _busRouteProvider.GetBusRoutesAsync<List<Route>>(routeServiceURL);
            this.Routes = from route in routes
                          //where route.ShortName != string.Empty && route.Description != string.Empty 
                          select new DisplayRouteData
                          {
                              Description = route.Description,
                              ShortName = route.ShortName,
                              PredictedArrival = route.PredictedArrivalTime
                          };
        }
    }

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
