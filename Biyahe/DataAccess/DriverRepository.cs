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




        //not yet used 
        public Driver GetDriverById(int driverId)
        {
            string selectSql = @"SELECT DirverID, FirstName, MiddleName, LastName, Username, emailAdd, SeniorOrPwd, Latitude, 
                       Longitude, LastLocated FROM Users WHERE DriverID = @driverId";

            using (var sqlConnect = new SqlConnection(DatabaseConfig.Connection))
            using (var sCmd = new SqlCommand(selectSql, sqlConnect))
            {
                sCmd.Parameters.AddWithValue("@DriverID", driverId);
                sqlConnect.Open();
                using (var reader = sCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Driver
                        {
                            DriverID = (int)reader["driverID"],
                            FirstName = reader["FirstName"].ToString(),
                            MiddleName = reader["MiddleName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Username = reader["Username"].ToString(),
                            emailAdd = reader["emailAdd"].ToString(),
                            PlateNumber = reader["PlateNumber"].ToString(),
                            MaxCapacity = (int)reader["MaxCapacity"],
                            OnTrip = (bool)reader["OnTrip"],
                            CurrentRouteID = (int)reader["CurrentRouteId"],

                        };
                    }
                }
            }
            return null;
        }//GetDriverbyID

        public bool setStatusDriver(int driverId, int routeId, bool onTrip)
        {
            string uStatusSql = @"UPDATE Drivers 
                          SET onTrip = @onTrip,
                              CurrentRouteID = @routeId
                          WHERE DriverID = @driverId";

            using var sqlConnect = new SqlConnection(DatabaseConfig.Connection);
            using var sCmd = new SqlCommand(uStatusSql, sqlConnect);

            sCmd.Parameters.AddWithValue("@driverId", driverId);
            sCmd.Parameters.AddWithValue("@routeId", routeId);
            sCmd.Parameters.AddWithValue("@onTrip", onTrip);

            sqlConnect.Open();

            int rowsAffected = sCmd.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public void UpdateLocation(int driverId, double lat, double lng)
        {
            string sql = @"UPDATE Drivers SET Latitude = @lat, Longitude = @lng, LastLocated = SYSDATETIME() 
                          WHERE DriverID = @driverId";

            using var conn = new SqlConnection(DatabaseConfig.Connection);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@driverId", driverId);
            cmd.Parameters.AddWithValue("@lat", lat);
            cmd.Parameters.AddWithValue("@lng", lng);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<object> GetActiveDriverLocationsByRoute(int routeId)
        {
            string sql = @"
        SELECT DriverID, FirstName, LastName, PlateNumber, Latitude, Longitude
        FROM Drivers
        WHERE CurrentRouteID = @routeId
          AND OnTrip = 1
          AND Latitude IS NOT NULL
          AND Longitude IS NOT NULL";

            var drivers = new List<object>();

            using var conn = new SqlConnection(DatabaseConfig.Connection);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@routeId", routeId);

            conn.Open();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                drivers.Add(new
                {
                    id = (int)reader["DriverID"],
                    lat = Convert.ToDouble(reader["Latitude"]),
                    lng = Convert.ToDouble(reader["Longitude"]),
                    label = reader["PlateNumber"].ToString()
                });
            }

            return drivers;
        }

    }//class
}//namespace
