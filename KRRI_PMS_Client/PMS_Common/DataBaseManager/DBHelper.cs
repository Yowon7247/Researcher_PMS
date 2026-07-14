using System.Data;
using MySqlConnector;

namespace PMS_Common.DataBaseManager
{
    public class DBHelper
    {
        private readonly DBManager _dbManager;

        public DBHelper(DBManager dbManager)
        {
            _dbManager = dbManager;
        }

        public DataTable ExecuteQuery(string sql, Dictionary<string, object>? parameters = null)
        {
            using var conn = _dbManager.CreateConnection();

            using var cmd = new MySqlCommand(sql, conn);

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            using var reader = cmd.ExecuteReader();

            DataTable table = new DataTable();

            table.Load(reader);

            return table;
        }

        public int ExecuteNonQuery(string sql, Dictionary<string, object>? parameters = null)
        {
            using var conn = _dbManager.CreateConnection();

            using var cmd = new MySqlCommand(sql, conn);

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            return cmd.ExecuteNonQuery();
        }

        public object? ExecuteScalar(string sql, Dictionary<string, object>? parameters = null)
        {
            using var conn = _dbManager.CreateConnection();

            using var cmd = new MySqlCommand(sql, conn);

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            return cmd.ExecuteScalar();
        }
    }
}