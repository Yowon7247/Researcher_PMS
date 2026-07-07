using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Common.Packets
{
    public class LoginRequest
    {
        public string ID { get; set; }

        public string PW { get; set; }
    }
}
