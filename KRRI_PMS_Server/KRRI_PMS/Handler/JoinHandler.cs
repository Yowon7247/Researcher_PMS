using System.Net.Sockets;
using PMS_Common.Header;
using PMS_Common.Network;
using PMS_Common.Packets;

namespace PMS_Server.Handler
{
    public class JoinHandler
    {
        public async Task ProcessAsync(PacketHeader header, JoinRequest request, NetworkStream stream)
        {
            JoinResponse response = new JoinResponse();

            // TODO
            // 아이디 중복 확인
            // 비밀번호 암호화
            // DB Insert

            response.Success = true;
            response.Message = "회원가입이 완료되었습니다.";

            byte[] packet =
                PacketSerializer.Serialize(
                    (ushort)PacketType.JoinResponse,
                    header.Version,
                    header.Sequence,
                    response);

            await stream.WriteAsync(packet);
        }
    }
}