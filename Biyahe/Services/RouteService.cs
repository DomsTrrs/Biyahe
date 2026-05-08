using Biyahe.DataAccess;
using Biyahe.Models;


namespace Biyahe.Services
{
    public class RouteService
    {
        private readonly RouteRepository _routeRepository = new RouteRepository();
        private readonly RouteStopsRepository _routeStopsRepository = new RouteStopsRepository();

        // For populating ComboBox in passenger and driver forms
        public List<Routes> GetActiveRoutes()
        {
            return _routeRepository.GetAllActiveRoutes();
        }

        // For displaying stop list or reference
        public string GetRouteStops(int routeId)
        {
            var stops = _routeStopsRepository.GetRouteStops(routeId);

            string coords = string.Join(",",
                stops.Select(s => $"[{s.Latitude},{s.Longitude}]")
            );

            return coords;
        }
    }
}
