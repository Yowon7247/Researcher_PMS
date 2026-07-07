using System;
using System.Text;
using System.Text.Json;
using PMS_Common.Header;

namespace PMS_Common.Network
{
    /// <summary>
    /// 패킷 직렬화 및 역직렬화를 담당하는 클래스입니다.
    /// Header와 Body를 하나의 byte 배열로 변환하여 전송하며,
    /// 수신한 byte 배열을 Header와 Body로 분리하는 기능을 제공합니다.
    /// </summary>
    public static class PacketSerializer
    {
        /// <summary>
        /// Header와 Body를 하나의 byte 배열로 직렬화합니다.
        /// </summary>
        /// <typeparam name="T">Body 객체 타입</typeparam>
        /// <param name="packetID">패킷 ID</param>
        /// <param name="version">프로토콜 버전</param>
        /// <param name="sequence">요청 번호</param>
        /// <param name="body">전송할 Body 객체</param>
        /// <returns>Header + Body가 합쳐진 byte 배열</returns>
        public static byte[] Serialize<T>(ushort packetID, ushort version, int sequence, T body)
        {
            byte[] bodyBytes =
                Encoding.UTF8.GetBytes(JsonSerializer.Serialize(body));

            PacketHeader header = new PacketHeader()
            {
                PacketID = packetID,
                Version = version,
                BodySize = bodyBytes.Length,
                Sequence = sequence
            };

            byte[] packet = new byte[12 + bodyBytes.Length];

            Buffer.BlockCopy(BitConverter.GetBytes(header.PacketID), 0, packet, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(header.Version), 0, packet, 2, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(header.BodySize), 0, packet, 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(header.Sequence), 0, packet, 8, 4);

            Buffer.BlockCopy(bodyBytes, 0, packet, 12, bodyBytes.Length);

            return packet;
        }

        /// <summary>
        /// 수신한 byte 배열에서 Header를 추출합니다.
        /// </summary>
        /// <param name="buffer">수신한 byte 배열</param>
        /// <returns>PacketHeader</returns>
        public static PacketHeader DeserializeHeader(byte[] buffer)
        {
            return new PacketHeader()
            {
                PacketID = BitConverter.ToUInt16(buffer, 0),
                Version = BitConverter.ToUInt16(buffer, 2),
                BodySize = BitConverter.ToInt32(buffer, 4),
                Sequence = BitConverter.ToInt32(buffer, 8)
            };
        }

        /// <summary>
        /// Header를 제외한 Body를 객체로 역직렬화합니다.
        /// </summary>
        /// <typeparam name="T">복원할 객체 타입</typeparam>
        /// <param name="buffer">수신한 byte 배열</param>
        /// <param name="header">PacketHeader</param>
        /// <returns>Body 객체</returns>
        public static T? DeserializeBody<T>(byte[] buffer, PacketHeader header)
        {
            string json = Encoding.UTF8.GetString(buffer, 0, header.BodySize);

            return JsonSerializer.Deserialize<T>(json);
        }
    }
}