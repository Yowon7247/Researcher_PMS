using System;

namespace PMS_Common.Packets
{
    /// <summary>
    /// 회원가입 요청 패킷
    /// 클라이언트에서 서버로 회원가입 정보를 전송합니다.
    /// </summary>
    public class JoinRequest
    {
        /// <summary>
        /// 사용자 아이디
        /// </summary>
        public string UserID { get; set; } = string.Empty;

        /// <summary>
        /// 비밀번호
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 사용자 이름
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 이메일 주소
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 연락처
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// 소속 부서
        /// </summary>
        public string Department { get; set; } = string.Empty;
    }
}