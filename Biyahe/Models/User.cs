using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biyahe.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string emailAdd { get; set; }
        public bool SeniorOrPwd { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? LastLocated { get; set; }



        //First constructor for inserting users
        public User(string firstName, string middleName, string lastName,
                string username, string password, string emailAdd, bool seniorOrPwd)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Username = username;
            this.Password = password;
            this.emailAdd = emailAdd;
            this.SeniorOrPwd = seniorOrPwd;
        }

        //for db purpose
        public User() { }
        
    }//class
}//namespace
