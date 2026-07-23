using PMS_Common.Packets;

namespace PMS_Client.Handler
{
    /// <summary>
    /// 회원가입 응답을 처리합니다.
    /// </summary>
    public class JoinResponseHandler
    {
        public async Task ProcessAsync(JoinResponse response)
        {
            if (response.Success)
            {
                Console.WriteLine("회원가입 성공");
                Console.WriteLine(response.Message);

                // TODO :
                // MessageBox.Show(response.Message);
                // 로그인 화면으로 이동
            }
            else
            {
                Console.WriteLine("회원가입 실패");
                Console.WriteLine(response.Message);

                // TODO :
                // MessageBox.Show(response.Message);
            }

            await Task.CompletedTask;
        }
    }
}