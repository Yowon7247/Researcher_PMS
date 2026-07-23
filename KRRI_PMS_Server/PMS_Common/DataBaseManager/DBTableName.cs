using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Common.DataBaseManager
{
    public static class DBTableName
    {
        // 사용자 정보
        public const string user = "tb_user";

        // 직책
        public const string position = "tb_position";

        // 로그인 기록
        public const string loginHistory = "tb_login_history";

        // 부서
        public const string department = "tb_department";

        // 사용권한
        public const string authority = "tb_authority";
    }
}
