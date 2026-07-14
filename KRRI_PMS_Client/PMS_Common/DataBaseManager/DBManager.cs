using MySqlConnector;

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

        /// <summary>
        /// 새로운 DB Connection을 생성하여 Open한 후 반환합니다.
        /// </summary>
        public MySqlConnection CreateConnection()
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            return conn;
        }

        /// <summary>
        /// DB 연결 테스트
        /// </summary>
        public bool Open()
        {
            try
            {
                using var conn = CreateConnection();

                LogManager.LogManager.Info(
                    "PMS_Common",
                    "Database connection successful.");

                return true;
            }
            catch (Exception ex)
            {
                LogManager.LogManager.Error(
                    "PMS_Common",
                    ex.ToString());

                return false;
            }
        }
    }
}