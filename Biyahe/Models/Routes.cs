using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biyahe.Models
{
    public class Routes
    {
        public int RouteID { get; set; }
        public string RouteName { get; set; }
        public string RouteDescription { get; set; } 
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public bool OnRoute { get; set; }   



    public Routes(string routeName, string routeDescription, string startPoint, string endPoint)
        {
            this.RouteName = routeName;
            this.RouteDescription = routeDescription;
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.OnRoute = false; //default value
        }//constructor routes

        //for db purpose
        public Routes() { } 

    }//class
}//namespace
