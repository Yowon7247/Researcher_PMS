using PMS_Common.DataBaseManager;
using PMS_Server.Model;
using MySqlConnector;

namespace PMS_Server.Repository
{
    public class UserRepository
    {
        private readonly DBManager _db;

        public UserRepository(DBManager db)
        {
            _db = db;
        }

        public UserInfo? Login(string id, string password)
        {
            string sql = @"
                SELECT
                    UserID,
                    UserName,
                    Department,
                    Position,
                    Authority
                FROM TB_USER
                WHERE UserID=@ID
                AND Password=@PW
                LIMIT 1;";

            using var conn = _db.CreateConnection();

            using var cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@PW", password);

            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            return new UserInfo()
            {
                UserID = reader.GetString("UserID"),
                UserName = reader.GetString("UserName"),
                IsAdmin = false
            };
        }
    }
}