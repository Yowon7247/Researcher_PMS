using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using PMS_Common.LogManager;

namespace PMS_Common.TCPManager
{
    public class TcpServerManager
    {
        private TcpListener? listener;

        public async Task StartAsync(int port)
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

                    _ = Task.Run(() => HandleClient(client));
                }
            }
            catch(Exception ex)
            {
                LogManager.LogManager.Error("PMS_Common", ex.ToString());
            }
        }

        private async Task HandleClient(TcpClient client)
        {
            Console.WriteLine("PMS_Client Connected");
            LogManager.LogManager.Info("PMS_Common", "PMS_Client Connected");

            NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[4096];

            while (true)
            {
                int size = await stream.ReadAsync(buffer);

                if (size == 0)
                    break;

                ushort packetType =BitConverter.ToUInt16(buffer, 0);

                int bodySize =
                    BitConverter.ToInt32(buffer, 2);

                string body =
                    Encoding.UTF8.GetString(buffer, 6, bodySize);

                byte[] send = Encoding.UTF8.GetBytes("OK");

                await stream.WriteAsync(send);
            }

            client.Close();
        }
    }
}
