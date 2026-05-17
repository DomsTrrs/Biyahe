using Microsoft.Data.SqlClient;
using Biyahe.Models;
using Biyahe.Config;


namespace Biyahe.DataAccess
{
    public class UserRepository
    {
        //adding user to db
        public void AddUser (User user)
        {
            string insertSql = @"INSERT INTO Users (FirstName, MiddleName, LastName, Username, Password, emailAdd, SeniorOrPwd)
                       VALUES (@FirstName, @MiddleName, @LastName, @Username, @Password, @emailAdd, @SeniorOrPwd)";


            //sql download from nuGet package 
            using (var sqlConnect = new SqlConnection(DatabaseConfig.Connection))
            using (var sCmd = new SqlCommand(insertSql, sqlConnect))
            {
                sCmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                sCmd.Parameters.AddWithValue("@MiddleName", user.MiddleName);
                sCmd.Parameters.AddWithValue("@LastName", user.LastName);
                sCmd.Parameters.AddWithValue("@Username", user.Username);
                sCmd.Parameters.AddWithValue("@Password", user.Password);
                sCmd.Parameters.AddWithValue("@emailAdd", user.emailAdd);
                sCmd.Parameters.AddWithValue("@SeniorOrPwd", user.SeniorOrPwd);

                sqlConnect.Open(); 
                sCmd.ExecuteNonQuery();
                sqlConnect.Close();
            }
            
        }//AddUser

        //finding user in sql   
        public User FindUserByUsername(string username)
        {
            string selectSql = "SELECT * FROM Users WHERE Username = @Username";

            using (var sqlConnect = new SqlConnection(DatabaseConfig.Connection))
            using (var sCmd = new SqlCommand(selectSql, sqlConnect))
            {
                sCmd.Parameters.AddWithValue("@Username", username);
                sqlConnect.Open();

                using (var reader = sCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserID = (int)reader["UserID"],
                            FirstName = reader["FirstName"].ToString(),
                            MiddleName = reader["MiddleName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            emailAdd = reader["emailAdd"].ToString(),
                            SeniorOrPwd = (bool)reader["SeniorOrPwd"]
                        };
                    }
                }
            }
            return null;
        }//FindUserByUsername

        public User GetUserById(int userId)
        {
            string selectSql = @"SELECT UserID, FirstName, MiddleName, LastName, Username, emailAdd, SeniorOrPwd, Latitude, 
                       Longitude, LastLocated FROM Users WHERE UserID = @userId";

            using (var sqlConnect = new SqlConnection(DatabaseConfig.Connection))
            using (var sCmd = new SqlCommand(selectSql, sqlConnect))
            {
                sCmd.Parameters.AddWithValue("@UserID", userId);
                sqlConnect.Open();
                using (var reader = sCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserID = (int)reader["UserID"],
                            FirstName = reader["FirstName"].ToString(),
                            MiddleName = reader["MiddleName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Username = reader["Username"].ToString(),
                            emailAdd = reader["emailAdd"].ToString(),
                            SeniorOrPwd = (bool)reader["SeniorOrPwd"],
                            Latitude = reader["Latitude"] as double?,
                            Longitude = reader["Longitude"] as double?,
                            LastLocated = reader["LastLocated"] as DateTime?,

                        };
                    }
                }
            }
            return null;
        }//GetUserById


        public void UpdateLocation(int userId, double lat, double lng)
        {
            string sql = @"UPDATE Users SET Latitude = @lat, Longitude = @lng, LastLocated = SYSDATETIME()
        WHERE UserID = @userId";

            using var conn = new SqlConnection(DatabaseConfig.Connection);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@lat", lat);
            cmd.Parameters.AddWithValue("@lng", lng);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

    }// UserRepository 
}//namespace
