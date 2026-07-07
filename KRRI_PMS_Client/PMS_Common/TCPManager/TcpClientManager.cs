using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using PMS_Common.Header;
using PMS_Common.Network;

namespace PMS_Common.TCPManager
{
    /// <summary>
    /// TCP 클라이언트 관리자
    /// 서버 연결, 패킷 송수신을 담당합니다.
    /// </summary>
    public class TcpClientManager
    {
        private TcpClient? _client;
        private NetworkStream? _stream;

        public bool IsConnected =>
            _client != null && _client.Connected;

        /// <summary>
        /// 서버 연결
        /// </summary>
        public async Task ConnectAsync(string ip, int port)
        {
            _client = new TcpClient();

            await _client.ConnectAsync(ip, port);

            _stream = _client.GetStream();
        }

        /// <summary>
        /// 패킷 전송
        /// </summary>
        public async Task SendPacketAsync(byte[] packet)
        {
            if (_stream == null)
                throw new InvalidOperationException("Is not connected PMS Server");

            await _stream.WriteAsync(packet, 0, packet.Length);
        }

        /// <summary>
        /// 패킷 수신 루프
        /// </summary>
        public async Task ReceiveLoopAsync(Func<PacketHeader, byte[], Task> packetHandler, CancellationToken token = default)
        {
            if (_stream == null)
                return;

            while (!token.IsCancellationRequested)
            {
                // Header 읽기
                byte[] headerBuffer = await ReadExactAsync(_stream, 12);

                PacketHeader header =
                    PacketSerializer.DeserializeHeader(headerBuffer);

                // Body 읽기
                byte[] bodyBuffer =
                    await ReadExactAsync(_stream, header.BodySize);

                await packetHandler(header, bodyBuffer);
            }
        }

        /// <summary>
        /// 정확한 길이만큼 읽는다.
        /// </summary>
        private static async Task<byte[]> ReadExactAsync(NetworkStream stream, int length)
        {
            byte[] buffer = new byte[length];

            int offset = 0;

            while (offset < length)
            {
                int read =
                    await stream.ReadAsync(buffer, offset, length - offset);

                if (read == 0)
                    throw new IOException("서버 연결이 종료되었습니다.");

                offset += read;
            }

            return buffer;
        }

        /// <summary>
        /// 서버 연결 종료
        /// </summary>
        public void Disconnect()
        {
            _stream?.Close();

            _client?.Close();
        }
    }
}