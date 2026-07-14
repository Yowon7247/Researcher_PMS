using PMS_Client.Dispatcher;
using PMS_Common.DataBaseManager;
using PMS_Common.iniReader;
using PMS_Common.LogManager;
using PMS_Common.TCPManager;
using PMS_Common.Variable;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace PMS_Client.Operation
{
    public class PmsClientStarted
    {
        public iniManager im = new iniManager(iniPath);
        public iniReader ir = new iniReader(iniPath);

        static string iniPath = Path.Combine(AppContext.BaseDirectory, "PMS_Config.ini");

        public void PmsStart(TcpClientManager _tcp)
        {
            IniRead();

            // 클라이언트는 DB에 접속하지 않는다.
            //DBConnect();

            // TCP 연결은 비동기적으로 수행
            //_ = Task.Run(() => _tcp.ConnectAsync(iniVariable.socketIP, int.Parse(iniVariable.socketPort)));

            _ = TCPConnect(_tcp);

            LogManager.Info("PMS_Client", "PMS Client has been executed.");
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
                iniVariable.AUserID = ir.Read(iniSection.Admin, "UserID");
                iniVariable.APassword = ir.Read(iniSection.Admin, "Password");

                LogManager.Info("PMS_Client", "Read ini file successful.");
            }
            catch (Exception ex)
            {
                LogManager.Error("PMS_Client", ex.ToString());
            }
        }

        //private void DBConnect()
        //{
        //    // Database connection logic here
        //    DBConfig config = new DBConfig()
        //    {
        //        Server = iniVariable.dbIP,
        //        Port = Int32.Parse(iniVariable.dbPort),
        //        Database = iniVariable.dbName,
        //        User = iniVariable.dbUser,
        //        Password = iniVariable.dbPassword
        //    };

        //    DBManager db = new DBManager(config);

        //    bool result = db.Open();

        //}

        private async Task TCPConnect(TcpClientManager tcp)
        {
            try
            {
                try
                {
                    // 1. 서버 연결 완료까지 기다림
                    await tcp.ConnectAsync(iniVariable.socketIP, int.Parse(iniVariable.socketPort));

                    // 2. Dispatcher 생성
                    ClientPacketDispatcher dispatcher = new();

                    // 3. 수신루프 시작
                    _ = Task.Run(() => tcp.ReceiveLoopAsync(dispatcher.DispatchAsync));
                }
                catch (Exception ex)
                {
                    LogManager.Error("PMS_Client", ex.ToString());
                }
            }
            catch (Exception ex)
            {
                LogManager.Error("PMS_Client", ex.ToString());
            }
        }
    }
}
