using Biyahe.Config;
using Biyahe.Models;
using Microsoft.Data.SqlClient;


namespace Biyahe.DataAccess
{
    public class DriverRepository
    {
        //add driver to db
        public void addDriver(Driver driver)
        {
            string insertSql = @"INSERT INTO Drivers (FirstName, MiddleName, LastName, Username, Password, emailAdd, PlateNumber)
                       VALUES (@FirstName, @MiddleName, @LastName, @Username, @Password, @emailAdd, @PlateNumber)";

            using (var sqlConnect = new SqlConnection(DatabaseConfig.Connection))
            using (var sCmd = new SqlCommand(insertSql, sqlConnect))
            {
                sCmd.Parameters.AddWithValue("@FirstName", driver.FirstName);
                sCmd.Parameters.AddWithValue("@MiddleName", driver.MiddleName);
                sCmd.Parameters.AddWithValue("@LastName", driver.LastName);
                sCmd.Parameters.AddWithValue("@Username", driver.Username);
                sCmd.Parameters.AddWithValue("@Password", driver.Password);
                sCmd.Parameters.AddWithValue("@emailAdd", driver.emailAdd);
                sCmd.Parameters.AddWithValue("@PlateNumber", driver.PlateNumber);

                sqlConnect.Open();
                sCmd.ExecuteNonQuery();
                sqlConnect.Close();
            }
        } //add driver 


        //Find driver in db 
        public Driver FindDriverByUsername(string username)
        {
            string selectSql = "SELECT * FROM Drivers WHERE Username = @Username";

            using (var sqlConnect = new SqlConnection(DatabaseConfig.Connection))
            using (var sCmd = new SqlCommand(selectSql, sqlConnect))
            {
                sCmd.Parameters.AddWithValue("@Username", username);
                sqlConnect.Open();

                using (var reader = sCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Driver
                        {
                            DriverID = (int)reader["DriverID"],
                            FirstName = reader["FirstName"].ToString(),
                            MiddleName = reader["MiddleName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            emailAdd = reader["emailAdd"].ToString(),
                            PlateNumber = reader["PlateNumber"].ToString(),
                        };
                    }
                }
            }
            return null;
        }//FindUserByUsername

    }//class
}//namespace
