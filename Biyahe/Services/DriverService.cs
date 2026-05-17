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

        public bool setOnTrip(int driverId, int routeId, bool onTrip) 
        {
            return _driverRepo.setStatusDriver(driverId, routeId, onTrip);
        }

        public bool unsetOnTrip(int driverId, int routeId, bool onTrip)
        {
            return _driverRepo.setStatusDriver(driverId, routeId, false);
        }

    }
}
