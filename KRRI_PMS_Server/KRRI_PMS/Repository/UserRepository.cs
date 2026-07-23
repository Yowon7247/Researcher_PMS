using PMS_Common.DataBaseManager;
using PMS_Common.LogManager;
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
            try
            {
                string sql = $@"
SELECT
    u.UserID,
    u.UserName,
    a.AuthorityName
FROM {DBTableName.user} u
INNER JOIN {DBTableName.authority} a ON u.AuthorityCode = a.AuthorityCode
WHERE u.UserID = @ID
AND u.UserPW = @PW
AND u.IsUse = 1
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
                    IsAdmin = reader.GetString("AuthorityName") == "Admin"
                };
            }
            catch (Exception ex)
            {
                LogManager.Error("PMS_Server", ex.ToString());
                throw;
            }
        }
    }
}