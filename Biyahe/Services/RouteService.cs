using Biyahe.DataAccess;
using Biyahe.Models;


namespace Biyahe.Services
{
    public class RouteService
    {
        private readonly RouteRepository _routeRepository = new RouteRepository();

        // For populating ComboBox in passenger and driver forms
        public List<Routes> GetActiveRoutes()
        {
            return _routeRepository.GetAllActiveRoutes();
        }

        // For displaying stop list or reference
        public List<RouteStops> GetRouteStops(int routeID)
        {
            return _routeRepository.GetRouteStops(routeID);
        }
    }
}
