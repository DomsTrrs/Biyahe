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

            if (user == null)
            {
                return null;
            }

            bool passCheck = BCrypt.Net.BCrypt.EnhancedVerify(password, user.Password);

            return passCheck ? user : null;
        }


        //driver login
        public Driver driverLogin(string username, string password)
        {
            Driver driver = _driverRepo.FindDriverByUsername(username);

            if (driver == null)
            {
                return null;
            }

            bool passCheck = BCrypt.Net.BCrypt.EnhancedVerify(password, driver.Password);

            return passCheck ? driver : null;
        }

    }//class
}//namespace
