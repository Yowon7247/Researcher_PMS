using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Common.DataBaseManager
{
    public class DBConfig
    {
        public string Server { get; set; } = "";
        public int Port { get; set; }
        public string Database { get; set; } = "";
        public string User { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
