using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using PMS_Common.LogManager;

namespace PMS_Common.DataBaseManager
{
    public class DBManager
    {
        private readonly string _connectionString;

        public DBManager(DBConfig config)
        {
            _connectionString =
                $"Server={config.Server};" +
                $"Port={config.Port};" +
                $"Database={config.Database};" +
                $"User ID={config.User};" +
                $"Password={config.Password};" +
                $"Charset=utf8mb4;";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public bool Open()
        {
            try
            {
                using var conn = GetConnection();
                conn.Open();
                LogManager.LogManager.Info("PMS_Common", "DataBase connection successful. DB Name: Researcher_PMS_v1");
                return true;
            }
            catch(Exception ex)
            {
                LogManager.LogManager.Error("PMS_Common", ex.ToString());
                return false;
            }
        }
    }
}
