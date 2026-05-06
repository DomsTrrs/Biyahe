using Biyahe.DataAccess;
using Biyahe.Models;

namespace Biyahe.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepo = new UserRepository();
        private readonly DriverRepository _driverRepo = new DriverRepository();

        //user login
        public User userLogin(string username, string password)
        {
            User user = _userRepo.FindUserByUsername(username);
            bool passCheck = BCrypt.Net.BCrypt.EnhancedVerify(password, user.Password);

            //check in db 
            if (user == null) {
                return null;
            } else if (passCheck)
            {
                return user;
            }

            return null;
        } //userLogin


       //driver login
        public Driver driverLogin(string username, string password)
        {

            Driver driver = _driverRepo.FindDriverByUsername(username);
            bool passCheck = BCrypt.Net.BCrypt.EnhancedVerify(password, driver.Password);

            //check in db and password
            if (driver == null)
            {
                return null;
            } else if (passCheck)
            {
                return driver;
            }

            return null;
        }//userLogin
    }//class
}//namespace
