using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Common.iniReader
{
    // iniManager를 상속받아 _filePath에 접근할 수 있도록 합니다.
    public class iniReader : iniManager
    {
        // 생성자를 통해 받은 filePath를 부모 클래스(iniManager)로 전달합니다.
        public iniReader(string filePath) : base(filePath)
        {
        }

        public string Read(string section, string key, string defaultValue = "")
        {
            StringBuilder value = new StringBuilder(255);

            iniManager.GetPrivateProfileString(
                section,
                key,
                defaultValue,
                value,
                value.Capacity,
                _filePath); // 이제 문제 없이 _filePath를 사용할 수 있습니다.

            return value.ToString();
        }
    }
}
