using PMS_Server.Repository;
using PMS_Server.Model;
using PMS_Common.Header;
using PMS_Common.Packets;
using System.Net.Sockets;
using PMS_Common.Variable;
using PMS_Common.Network;


namespace PMS_Server.Handler
{
    public class LoginHandler
    {
        public async Task ProcessAsync(PacketHeader header, LoginRequest request, NetworkStream stream)
        {
            LoginResponse response = new();

            //----------------------------------------------------
            // 관리자 로그인
            //----------------------------------------------------
            if (request.ID == iniVariable.AUserID &&
                request.PW == iniVariable.APassword)
            {
                response.Success = true;
                response.IsAdmin = true;
                response.UserName = "관리자";
                response.Message = "관리자 로그인";
            }
            else
            {
                //------------------------------------------------
                // 일반 사용자 조회
                //------------------------------------------------

                UserRepository repository = new(ServerContext.DB);

                UserInfo? user =
                    repository.Login(request.ID, request.PW);

                if (user != null)
                {
                    response.Success = true;
                    response.IsAdmin = false;
                    response.UserName = user.UserName;
                    response.Message = "로그인 성공";
                }
                else
                {
                    response.Success = false;
                    response.IsAdmin = false;
                    response.Message = "아이디 또는 비밀번호를 확인하세요.";
                }
            }

            byte[] packet =
                PacketSerializer.Serialize(
                    (ushort)PacketType.LoginResponse,
                    header.Version,
                    header.Sequence,
                    response);

            await stream.WriteAsync(packet);
        }
    }
}