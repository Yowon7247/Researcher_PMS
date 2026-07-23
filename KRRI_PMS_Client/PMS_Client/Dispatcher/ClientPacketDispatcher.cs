using PMS_Common.Header;
using PMS_Common.Network;
using PMS_Common.Packets;
using PMS_Client.Handler;

namespace PMS_Client.Dispatcher
{
    /// <summary>
    /// 서버에서 수신한 패킷을 PacketID에 따라 분배합니다.
    /// </summary>
    public class ClientPacketDispatcher
    {
        public async Task DispatchAsync(PacketHeader header, byte[] body)
        {
            switch ((PacketType)header.PacketID)
            {
                case PacketType.LoginResponse:
                    {
                        LoginResponse? response =
                            PacketSerializer.DeserializeBody<LoginResponse>(body);

                        if (response != null)
                        {
                            LoginResponseHandler handler = new();

                            await handler.ProcessAsync(response);
                        }

                        break;
                    }

                case PacketType.JoinResponse:
                    {
                        JoinResponse? response =
                            PacketSerializer.DeserializeBody<JoinResponse>(body);

                        if (response != null)
                        {
                            JoinResponseHandler handler = new();

                            await handler.ProcessAsync(response);
                        }

                        break;
                    }

                case PacketType.ResearcherSearchResponse:
                    {
                        //ResearcherSearchResponse? response =
                        //    PacketSerializer.DeserializeBody<ResearcherSearchResponse>(body, header);

                        //if (response != null)
                        //{
                        //    ResearcherResponseHandler handler = new();

                        //    await handler.ProcessAsync(response);
                        //}

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