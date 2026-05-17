using Biyahe.Config;
using Biyahe.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biyahe.DataAccess
{
    public class QueueRepository
    {
           //join queue 
        public (int queueId, int position) JoinQueue(int userId, int routeId, bool isPriority)
        {
                using var sqlConnect = new SqlConnection(DatabaseConfig.Connection);
                sqlConnect.Open();

                using var transaction = sqlConnect.BeginTransaction();

                try
                {
                    string positionSql = @"SELECT ISNULL(MAX(QueuePosition), 0) + 1 FROM [Queue] WITH (UPDLOCK, HOLDLOCK) 
                                         WHERE RouteID = @routeId AND Status = 'Waiting'";

                    int position;

                    using (var positionCmd = new SqlCommand(positionSql, sqlConnect, transaction))
                    {
                        positionCmd.Parameters.AddWithValue("@routeId", routeId);
                        position = Convert.ToInt32(positionCmd.ExecuteScalar());
                    }

                    string insertSql = @"INSERT INTO [Queue] (UserID, RouteID, QueuePosition, Status, IsPriority)
                                        OUTPUT INSERTED.QueueID VALUES (@userId, @routeId, @queuePosition, 'Waiting', @isPriority)";

                    int queueId;

                    using (var insertCmd = new SqlCommand(insertSql, sqlConnect, transaction))
                    {
                        insertCmd.Parameters.AddWithValue("@userId", userId);
                        insertCmd.Parameters.AddWithValue("@routeId", routeId);
                        insertCmd.Parameters.AddWithValue("@queuePosition", position);
                        insertCmd.Parameters.AddWithValue("@isPriority", isPriority);

                        queueId = Convert.ToInt32(insertCmd.ExecuteScalar());
                    }

                    transaction.Commit();
                    return (queueId, position);
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }


            //Get waiting queue for a route (priority first, then by position)
            public List<QueueEntry> GetQueueByRoute(int routeId)
            {
                string queueSql = @"
                    SELECT 
                        q.QueueID,
                        q.UserID,
                        q.RouteID,
                        q.DriverID,
                        q.IsPriority,
                        q.Status,
                        q.QueuePosition,
                        q.JoinedAt,
                        CONCAT(u.FirstName, ' ', u.LastName) AS UserFullName,
                        r.RouteName AS RouteCode
                    FROM [Queue] q
                    JOIN Users u ON q.UserID = u.UserID
                    JOIN Routes r ON q.RouteID = r.RouteID
                    WHERE q.RouteID = @routeId 
                      AND q.Status = 'Waiting'
                    ORDER BY q.IsPriority DESC, q.QueuePosition ASC";

                var list = new List<QueueEntry>();

                using var sqlConnect = new SqlConnection(DatabaseConfig.Connection);
                using var sqlCmd = new SqlCommand(queueSql, sqlConnect);

                sqlCmd.Parameters.AddWithValue("@routeId", routeId);
                sqlConnect.Open();

                using var reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    var entry = new QueueEntry
                    {
                        QueueID = reader.GetInt32(reader.GetOrdinal("QueueID")),
                        UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                        RouteID = reader.GetInt32(reader.GetOrdinal("RouteID")),
                        DriverID = reader.IsDBNull(reader.GetOrdinal("DriverID")) ? null : reader.GetInt32(reader.GetOrdinal("DriverID")),
                        IsPriority = reader.GetBoolean(reader.GetOrdinal("IsPriority")),
                        Status = reader.GetString(reader.GetOrdinal("Status")),
                        QueuePosition = reader.IsDBNull(reader.GetOrdinal("QueuePosition")) ? null : reader.GetInt32(reader.GetOrdinal("QueuePosition")),
                        JoinedAt = reader.GetDateTime(reader.GetOrdinal("JoinedAt")),
                        UserFullName = reader.GetString(reader.GetOrdinal("UserFullName")),
                        RouteCode = reader.GetString(reader.GetOrdinal("RouteCode"))
                    };

                    list.Add(entry);
                }

                return list;
            }

            //board passengers (update status to Boarding and assign driver)
            public void BoardPassengers(List<int> queueIDs, int driverID)
            {
                string boardSql = @"
                    UPDATE [Queue]
                    SET Status = 'Boarding',
                        DriverID = @driverId
                    WHERE QueueID = @queueId
                      AND Status = 'Waiting'";

                using var sqlConnect = new SqlConnection(DatabaseConfig.Connection);
                sqlConnect.Open();

                foreach (var queueID in queueIDs)
                {
                    using var sCmd = new SqlCommand(boardSql, sqlConnect);

                    sCmd.Parameters.AddWithValue("@driverId", driverID);
                    sCmd.Parameters.AddWithValue("@queueId", queueID);

                    sCmd.ExecuteNonQuery();
                }
            }


            //cancel queue (update status to Cancelled)
            public void CancelQueue(int queueId, int routeId)
            {
                string cancelSql = @"UPDATE [Queue] SET Status = 'Cancelled' WHERE QueueID = @queueId AND RouteID = @routeId";
                using var sqlConnect = new SqlConnection(DatabaseConfig.Connection);
                using var sCmd = new SqlCommand(cancelSql, sqlConnect);
                {
                    sCmd.Parameters.AddWithValue("@queueId", queueId);
                    sCmd.Parameters.AddWithValue("@routeId", routeId);

                    sqlConnect.Open();
                    sCmd.ExecuteNonQuery();
                    sqlConnect.Close();
                }
            }

        //get queue position for a user in a route 
        //use this for boarding logic
        public int? GetQueuePosition(int queueId)
        {
            string getSql = @"SELECT QueuePosition FROM [Queue] WHERE QueueID = @queueId";

            using var sqlConnect = new SqlConnection(DatabaseConfig.Connection);
            using var sCmd = new SqlCommand(getSql, sqlConnect);

            sCmd.Parameters.AddWithValue("@queueId", queueId);

            sqlConnect.Open();

            var result = sCmd.ExecuteScalar();

            if (result == null || result == DBNull.Value)
            {
                return null;
            }

            return Convert.ToInt32(result);
        }

        public List<object> GetQueuedUserLocationsByRoute(int routeId)
        {
            string sql = @"
        SELECT u.UserID, u.FirstName, u.LastName, u.Latitude, u.Longitude
        FROM [Queue] q
        JOIN Users u ON q.UserID = u.UserID
        WHERE q.RouteID = @routeId
          AND q.Status IN ('Waiting', 'Boarding')
          AND u.Latitude IS NOT NULL
          AND u.Longitude IS NOT NULL";

            var users = new List<object>();

            using var conn = new SqlConnection(DatabaseConfig.Connection);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@routeId", routeId);

            conn.Open();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new
                {
                    id = (int)reader["UserID"],
                    lat = Convert.ToDouble(reader["Latitude"]),
                    lng = Convert.ToDouble(reader["Longitude"]),
                    label = reader["FirstName"].ToString() + " " + reader["LastName"].ToString()
                });
            }

            return users;
        }

        public bool UnboardPassenger(int queueId, int userId)
        {
            string uSql = @" UPDATE [Queue] SET Status = 'Boarded' WHERE QueueID = @queueId AND UserID = @userId AND Status = 'Boarding'";

            using var sqlConnection = new SqlConnection(DatabaseConfig.Connection);
            using var cmd = new SqlCommand(uSql, sqlConnection);

            cmd.Parameters.AddWithValue("@queueId", queueId);
            cmd.Parameters.AddWithValue("@userId", userId);

            sqlConnection.Open();

            return cmd.ExecuteNonQuery() > 0;
        }
    }//class
}//QueueRepository
