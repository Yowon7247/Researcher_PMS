using PMS_Common.Packets;

namespace PMS_Client.Events
{
    /// <summary>
    /// 서버 응답을 UI로 전달하기 위한 이벤트 모음
    /// </summary>
    public static class ClientEvents
    {
        public static event Action<LoginResponse>? LoginResponded;

        public static void RaiseLoginResponded(LoginResponse response)
        {
            LoginResponded?.Invoke(response);
        }
    }
}