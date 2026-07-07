using PMS_Common.Header;
using PMS_Common.Network;
using PMS_Common.Packets;
using PMS_Common.TCPManager;
using PMS_Common.Variable;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Client.Operation
{
    public class LoginOperation
    {
        private readonly TcpClientManager _tcp;

        private readonly string _id;

        private readonly string _password;

        public LoginOperation(TcpClientManager tcp,string id,string password)
        {
            _tcp = tcp;

            _id = id;

            _password = password;
        }

        public async Task SendLoginRequest()
        {
            LoginRequest request = new LoginRequest()
            {
                ID = _id,
                PW = _password
            };

            byte[] packet = PacketSerializer.Serialize((ushort)PacketType.LoginRequest, 1, 1, request);

            await _tcp.SendPacketAsync(packet);
        }
    }
}
