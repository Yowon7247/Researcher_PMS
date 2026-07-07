using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Common.Header
{
    public struct PacketHeader
    {
        public ushort PacketID;      // Login, Join ...

        public ushort Version;       // 프로토콜 버전

        public int BodySize;         // Body 길이

        public int Sequence;         // 요청 번호
    }
}
