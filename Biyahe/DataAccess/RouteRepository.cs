using Biyahe.Config;
using Biyahe.Models;
using Microsoft.Data.SqlClient;

namespace Biyahe.DataAccess
{
    public class RouteRepository
    {
        public List<Routes> GetAllActiveRoutes()
        {
            List<Routes> list = new List<Routes>();

            string selectSql = "SELECT * FROM Routes WHERE OnRoute = 1 ORDER BY RouteName";

            using (var sqlConnect = new SqlConnection(DatabaseConfig.Connection))
            using (var sCmd = new SqlCommand(selectSql, sqlConnect))
            {
                sqlConnect.Open(); 

                using (var reader = sCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Routes route = new Routes
                        {
                            RouteID = (int)reader["RouteID"],
                            RouteName = reader["RouteName"].ToString(),
                            RouteDescription = reader["RouteDescription"].ToString(),
                            StartPoint = reader["StartPoint"].ToString(),
                            EndPoint = reader["EndPoint"].ToString(),
                            OnRoute = (bool)reader["OnRoute"]
                        };
                        list.Add(route);
                    }
                }
            }
            return list;
        }//GatAllActiveRoutes
    }//class
}//namespace
