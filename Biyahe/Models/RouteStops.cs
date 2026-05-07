using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biyahe.Models
{
    public class RouteStops
    {
        public int StopID { get; set; }
        public int RouteID { get; set; }
        public string StopName { get; set; }
        public int StopOrder { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


        public RouteStops(int StopID,  int routeID, string stopName, int StopOrder,double latitude, double longitude)
        {
            this.StopID = StopID;
            this.RouteID = routeID;
            this.StopName = stopName;
            this.StopOrder = StopOrder;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }//constructor RouteStops

        //for db purpose
        public RouteStops() { } 

    }//class 
}//namespace
