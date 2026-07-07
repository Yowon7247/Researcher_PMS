using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Server.Model
{
    public class UserInfo
    {
        public string UserID { get; set; } = "";
        public string UserName { get; set; } = "";
        public bool IsAdmin { get; set; }
    }
}
