using System;

namespace PMS_Common.Packets
{
    /// <summary>
    /// 연구원 정보
    /// </summary>
    public class ResearcherInfo
    {
        /// <summary>
        /// 연구원 번호
        /// </summary>
        public int ResearcherNo { get; set; }

        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 부서
        /// </summary>
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// 직급
        /// </summary>
        public string Position { get; set; } = string.Empty;

        /// <summary>
        /// 연락처
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// 이메일
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}