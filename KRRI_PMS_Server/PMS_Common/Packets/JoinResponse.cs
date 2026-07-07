using System;

namespace PMS_Common.Packets
{
    /// <summary>
    /// 회원가입 응답 패킷
    /// </summary>
    public class JoinResponse
    {
        /// <summary>
        /// 회원가입 성공 여부
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 사용자에게 표시할 메시지
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// 생성된 회원 번호(회원가입 성공 시)
        /// </summary>
        public int UserNo { get; set; }

        /// <summary>
        /// 생성된 사용자 ID
        /// </summary>
        public string UserID { get; set; } = string.Empty;
    }
}