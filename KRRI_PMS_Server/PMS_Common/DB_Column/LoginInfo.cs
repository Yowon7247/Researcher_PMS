using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Common.DB_Column
{
    [Serializable]
    internal class LoginInfo
    {
        // 아이디, 사번
        public int UserID;

        // 비밀번호
        public string Password;

        // 사용자 이름
        public string UserName;

        // 이메일
        public string Email;

        // 사용자 권한 및 직급
        public string Role;

        // 가입 일자
        public DateTime CreatedAt;

    }
}
