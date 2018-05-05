using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BusInfo.API.Controllers
{
    [Route("api/[controller]")]
    public class RoutesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Route>> Get()
        {
            var routesMock = new MockBusLocator();
            var routesJson = await routesMock.GetJsonForStopsAsync();
            List<Route> routes = JsonConvert.DeserializeObject<List<Route>>(routesJson);
            return routes;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
