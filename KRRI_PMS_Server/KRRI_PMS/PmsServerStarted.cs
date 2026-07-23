using PMS_Common;
using PMS_Common.DataBaseManager;
using PMS_Common.iniReader;
using PMS_Common.LogManager;
using PMS_Common.TCPManager;
using PMS_Common.Variable;
using PMS_Server.Dispatcher;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Server
{
    public class PmsServerStarted
    {
        private TcpServerManager _server = new TcpServerManager();
        public iniManager im = new iniManager(iniPath);
        public iniReader ir = new iniReader(iniPath);

        static string iniPath = Path.Combine(AppContext.BaseDirectory, "PMS_Config.ini");

        public void PmsStart()
        {
            IniRead();
            DBConnect();

            //_ = Task.Run(() => _server.StartAsync(int.Parse(iniVariable.socketPort)));
            _ = TCPConnect();

            LogManager.Info("PMS_Server", "PMS Server has been executed.");
        }

        private void IniRead()
        {
            try
            {
                iniVariable.socketIP = ir.Read(iniSection.Socket, "IP");
                iniVariable.socketPort = ir.Read(iniSection.Socket, "Port");
                iniVariable.dbIP = ir.Read(iniSection.DB, "IP");
                iniVariable.dbPort = ir.Read(iniSection.DB, "Port");
                iniVariable.dbUser = ir.Read(iniSection.DB, "User");
                iniVariable.dbPassword = ir.Read(iniSection.DB, "Password");
                iniVariable.dbName = ir.Read(iniSection.DB, "DatabaseName");

                LogManager.Info("PMS_Server", "Read ini file successful.");
            }
            catch(Exception ex)
            {
                LogManager.Error("PMS_Server", ex.ToString());
            }
        }

        private void DBConnect()
        {
            // Database connection logic here
            DBConfig config = new DBConfig()
            {
                Server = iniVariable.dbIP,
                Port = Int32.Parse(iniVariable.dbPort),
                Database = iniVariable.dbName,
                User = iniVariable.dbUser,
                Password = iniVariable.dbPassword
            };

            ServerContext.DB = new DBManager(config);

            ServerContext.DB.Open();

        }

        private async Task TCPConnect()
        {
            try
            {
                // TCP connection logic here
                TcpServerManager serverTcp = new TcpServerManager();
                ServerPacketDispatcher dispatcher = new ServerPacketDispatcher();
                await serverTcp.StartAsync(Int32.Parse(iniVariable.socketPort), dispatcher.DispatchAsync);
            }
            catch (Exception ex)
            {
                LogManager.Error("PMS_Server", ex.ToString());
            }
        }
    }

    public static class ServerContext
    {
        public static DBManager DB { get; set; } = null!;
    }
}
