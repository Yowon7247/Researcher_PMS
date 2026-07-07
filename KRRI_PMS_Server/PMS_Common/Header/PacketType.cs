using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Common.Header
{
    public enum PacketType : ushort
    {
        None = 0,

        // 로그인
        LoginRequest = 1000,
        LoginResponse = 1001,

        // 회원가입
        JoinRequest = 1100,
        JoinResponse = 1101,

        // 연구원
        ResearcherSearchRequest = 2000,
        ResearcherSearchResponse = 2001,

        // 프로젝트
        ProjectRequest = 3000,
        ProjectResponse = 3001
    }
}
