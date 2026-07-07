using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Common.TCPManager
{
    public class Packet
    {
        public int Command { get; set; }

        public int Sequence { get; set; }

        public DateTime Time { get; set; } = DateTime.Now;

        public string Data { get; set; } = "";
    }
}
