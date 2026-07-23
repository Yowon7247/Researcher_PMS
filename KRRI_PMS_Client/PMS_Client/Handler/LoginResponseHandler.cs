using PMS_Client.Events;
using PMS_Common.LogManager;
using PMS_Common.Packets;

namespace PMS_Client.Handler
{
    /// <summary>
    /// 로그인 응답 처리
    /// </summary>
    public class LoginResponseHandler
    {
        public async Task ProcessAsync(LoginResponse response)
        {
            if (response.Success)
            {
                if (response.IsAdmin)
                {
                    Console.WriteLine("관리자 로그인");
                    LogManager.Info("PMS_Client", $"관리자 로그인");
                }
                else
                {
                    Console.WriteLine($"{response.UserName} 로그인");
                    LogManager.Info("PMS_Client", $"{response.UserName} 로그인");
                }
            }
            else
            {
                Console.WriteLine(response.Message);
                LogManager.Error("PMS_Client", $"로그인 실패: {response.Message}");
            }

            // 이밴트 발생
            ClientEvents.RaiseLoginResponded(response);

            await Task.CompletedTask;
        }
    }
}