using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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

        // SELECT
        public DataTable ExecuteQuery(string sql, Dictionary<string, object>? parameters = null)
        {
            using var conn = _dbManager.GetConnection();
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            using var adapter = new MySqlDataAdapter(cmd);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        // INSERT / UPDATE / DELETE
        public int ExecuteNonQuery(string sql, Dictionary<string, object>? parameters = null)
        {
            using var conn = _dbManager.GetConnection();
            conn.Open();

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

        // 단일 값 조회
        public object? ExecuteScalar(string sql, Dictionary<string, object>? parameters = null)
        {
            using var conn = _dbManager.GetConnection();
            conn.Open();

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
