using Biyahe.DataAccess;
using Biyahe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biyahe.Services
{
    public class DriverService
    {
        private readonly DriverRepository _driverRepo = new DriverRepository();

        public bool setOnTrip(int routeId, int driverId, bool onTrip) 
        {
            return _driverRepo.setStatusDriver(routeId, driverId, onTrip);
        }

        public bool unsetOnTrip(int routeId, int driverId, bool onTrip)
        {
            return _driverRepo.setStatusDriver(routeId, driverId, false);
        }

    }
}
