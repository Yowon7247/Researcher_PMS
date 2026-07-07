using System;

namespace PMS_Common.Packets
{
    /// <summary>
    /// 연구원 조회 요청 패킷
    /// </summary>
    public class ResearcherSearchRequest
    {
        /// <summary>
        /// 연구원 번호
        /// </summary>
        public int ResearcherNo { get; set; }

        /// <summary>
        /// 연구원 이름
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 부서명
        /// </summary>
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// 직급
        /// </summary>
        public string Position { get; set; } = string.Empty;

        /// <summary>
        /// 재직 여부
        /// true : 재직
        /// false : 퇴사
        /// null : 전체 조회
        /// </summary>
        public bool? IsWorking { get; set; }
    }
}