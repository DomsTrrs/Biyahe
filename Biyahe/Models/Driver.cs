using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biyahe.Models
{
    public class Driver
    {
        public int DriverID { get; set; }   
        public string FirstName { get; set; }
        public string MiddleName { get; set; }  
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string emailAdd { get; set; }
        public string PlateNumber { get; set; }
        public int MaxCapacity { get; set; }
        public bool OnTrip { get; set; }
        public int? CurrentRouteID { get; set; } //route id fk in db
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? LastLocated { get; set; }

        //inserting driver constructor
        public Driver(string firstName, string middleName, string lastName,
               string username, string password, string emailAdd, string plateNumber)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Username = username;
            this.Password = password;
            this.emailAdd = emailAdd;
            this.PlateNumber = plateNumber;
        }//constructor driver

        //for db purpose
        public Driver() { }

    }//class
}//namespace
