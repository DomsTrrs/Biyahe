using Biyahe.Config;
using Biyahe.Models;
using Microsoft.Data.SqlClient;

namespace Biyahe.DataAccess
{
    public class RouteStopsRepository
    {
        public List<RouteStops> GetRouteStops(int RouteID)
        {
            List<RouteStops> list = new List<RouteStops>();

            string selectSql = "SELECT * FROM RouteStops WHERE RouteID = @RouteID ORDER BY StopOrder";

            using (var sqlConnect = new SqlConnection(DatabaseConfig.Connection))
            using (var sCmd = new SqlCommand(selectSql, sqlConnect))
            {
                sCmd.Parameters.AddWithValue("@RouteID", RouteID);
                sqlConnect.Open();

                using (var reader = sCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RouteStops stop = new RouteStops
                        {
                            StopID = (int)reader["StopID"],
                            RouteID = (int)reader["RouteID"],
                            StopName = reader["StopName"].ToString(),
                            StopOrder = (int)reader["StopOrder"],
                            Latitude = Convert.ToDouble(reader["Latitude"]), 
                            Longitude = Convert.ToDouble(reader["Longitude"])
                        };
                        list.Add(stop);
                    }
                }
            }
            return list;
        }//GetRouteStops
    }
}
