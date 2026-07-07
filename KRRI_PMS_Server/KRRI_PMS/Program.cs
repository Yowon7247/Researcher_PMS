using System;
using System.Collections.Generic;
using System.Text;
using PMS_Server;

namespace PMS_Common.DB_Column
{
    class Program
    {
        static async Task Main(string[] args)
        {
            PmsServerStarted server = new();

            server.PmsStart();

            // 프로그램이 종료되지 않도록 유지
            await Task.Delay(Timeout.Infinite);
        }
    }
}