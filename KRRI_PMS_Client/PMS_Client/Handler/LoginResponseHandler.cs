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
                }
                else
                {
                    Console.WriteLine($"{response.UserName} 로그인");
                }
            }
            else
            {
                Console.WriteLine(response.Message);
            }

            await Task.CompletedTask;
        }
    }
}