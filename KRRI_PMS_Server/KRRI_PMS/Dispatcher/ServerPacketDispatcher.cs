using PMS_Common.Header;
using PMS_Common.Network;
using PMS_Common.Packets;
using PMS_Server.Handler;
using System;
using System.Net.Sockets;
using System.Text.Json;

namespace PMS_Server.Dispatcher
{
    public class ServerPacketDispatcher
    {
        public async Task DispatchAsync(TcpClient client, PacketHeader header, byte[] body, NetworkStream stream)
        {
            switch ((PacketType)header.PacketID)
            {
                // 로그인
                case PacketType.LoginRequest:
                    {
                        LoginRequest? request = PacketSerializer.DeserializeBody<LoginRequest>(body, header);

                        if (request != null)
                        {
                            LoginHandler loginHandler = new LoginHandler();

                            await loginHandler.ProcessAsync(
                                header,
                                request,
                                stream);
                        }

                        break;
                    }

                // 회원가입
                case PacketType.JoinRequest:
                    {
                        // JoinRequest request =
                        //      JsonSerializer.Deserialize<JoinRequest>(body);
                        //
                        // JoinHandler handler = new JoinHandler();
                        // await handler.ProcessAsync(header, request, stream);

                        break;
                    }

                // 연구원 조회
                case PacketType.ResearcherSearchRequest:
                    {
                        // 추후 구현

                        break;
                    }

                default:
                    {
                        Console.WriteLine($"Unknown Packet : {header.PacketID}");
                        break;
                    }
            }
        }
    }
}