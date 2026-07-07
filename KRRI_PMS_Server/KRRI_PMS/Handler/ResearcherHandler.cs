using System.Net.Sockets;
using PMS_Common.Header;
using PMS_Common.Network;
using PMS_Common.Packets;

namespace PMS_Server.Handler
{
    public class ResearcherHandler
    {
        public async Task ProcessAsync(PacketHeader header,ResearcherSearchRequest request, NetworkStream stream)
        {
            ResearcherSearchResponse response = new ResearcherSearchResponse();

            // TODO
            // DB 조회

            byte[] packet =
                PacketSerializer.Serialize(
                    (ushort)PacketType.ResearcherSearchResponse,
                    header.Version,
                    header.Sequence,
                    response);

            await stream.WriteAsync(packet);
        }
    }
}