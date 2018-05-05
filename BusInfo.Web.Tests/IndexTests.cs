using BusInfo.Web.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusInfoHelpers;

namespace BusInfo.Web.Tests
{
    [TestClass]
    public class IndexTests
    {
        [TestMethod]
        public async Task RouteDataLoading()
        {
            IndexModel page = new IndexModel(new BusRouteProvider());
            await page.OnGetAsync();

            Assert.IsNotNull(page.Routes);
        }

        [TestMethod]
        public async Task RouteDataIsCorrect()
        {
            IndexModel page = new IndexModel(new BusRouteProvider());
            await page.OnGetAsync();

            foreach(var route in page.Routes)
            {
                Assert.IsFalse(string.IsNullOrEmpty(route.Description));
                Assert.IsFalse(string.IsNullOrEmpty(route.ShortName));
            }
            
        }

        [TestMethod]
        public async Task DisplayTimeIsCorrect()
        {
            IndexModel page = new IndexModel(new BusRouteProvider());
            await page.OnGetAsync();

            DisplayRouteData displayRouteData = page.Routes.ToList()[0];
            var displayTime = displayRouteData.DisplayArrivalTime;
            var expectedDisplay = BusHelpers.ConvertMillisecondsToUTC(displayRouteData.PredictedArrival).ToShortTimeString();
            BusHelpers.CleanRouteName("");
            Assert.AreEqual("12:00 AM", displayTime);
        }
    }

    public class BusRouteProvider : IWebRequestProvider
    {
        public async Task<T> GetBusRoutesAsync<T>(string url)
        {
            var routesMock = new MockBusLocator();
            var routesJson = await routesMock.GetJsonForStopsAsync();
            T routes = JsonConvert.DeserializeObject<T>(routesJson);
            return routes;
        }
    }
}
