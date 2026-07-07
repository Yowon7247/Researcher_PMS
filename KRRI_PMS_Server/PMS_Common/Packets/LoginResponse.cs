using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Common.Packets
{
    public class LoginResponse
    {
        public bool Success { get; set; }

        public bool IsAdmin { get; set; }

        public string Message { get; set; }

        public int UserNo { get; set; }

        public string UserName { get; set; }
    }
}
