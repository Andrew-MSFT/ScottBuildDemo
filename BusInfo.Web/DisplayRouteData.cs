using System;

namespace BusInfo.Web
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
}
