using PMS_Common.Header;
using PMS_Common.LogManager;
using PMS_Common.Network;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PMS_Common.TCPManager
{
    public class TcpServerManager
    {
        private TcpListener? listener;

        public async Task StartAsync(int port, Func<TcpClient, PacketHeader, byte[], NetworkStream, Task> packetHandler)
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();

                Console.WriteLine($"PMS_Server Running for TCP: {port}");
                LogManager.LogManager.Info("PMS_Common", $"PMS_Server Running for TCP : {port}");

                while (true)
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();

                    _ = Task.Run(() => HandleClient(client, packetHandler));
                }
            }
            catch(Exception ex)
            {
                LogManager.LogManager.Error("PMS_Common", ex.ToString());
            }
        }

        private async Task HandleClient(TcpClient client, Func<TcpClient, PacketHeader, byte[], NetworkStream, Task> packetHandler)
        {
            NetworkStream stream = client.GetStream();

            while (true)
            {
                byte[] headerBuffer =
                    await ReadExactAsync(stream, 12);

                PacketHeader header = PacketSerializer.DeserializeHeader(headerBuffer);

                byte[] bodyBuffer = await ReadExactAsync(stream, header.BodySize);

                await packetHandler(client, header, bodyBuffer, stream);
            }
        }

        private static async Task<byte[]> ReadExactAsync(NetworkStream stream, int length)
        {
            byte[] buffer = new byte[length];

            int offset = 0;

            while (offset < length)
            {
                int read = await stream.ReadAsync(buffer, offset, length - offset);

                if (read == 0)
                    throw new IOException("Client disconnected.");

                offset += read;
            }

            return buffer;
        }
    }
}
