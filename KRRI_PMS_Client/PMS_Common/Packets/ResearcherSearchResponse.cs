using System.Collections.Generic;

namespace PMS_Common.Packets
{
    /// <summary>
    /// 연구원 조회 응답 패킷
    /// </summary>
    public class ResearcherSearchResponse
    {
        /// <summary>
        /// 조회 성공 여부
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 결과 메시지
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// 조회된 연구원 목록
        /// </summary>
        public List<ResearcherInfo> Researchers { get; set; } = new();

        /// <summary>
        /// 조회 건수
        /// </summary>
        public int Count => Researchers.Count;
    }
}