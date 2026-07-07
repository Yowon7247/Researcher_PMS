using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PMS_Common.iniReader
{
    public class iniManager
    {
        public readonly string _filePath;

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetPrivateProfileString(
        string section,
        string key,
        string defaultValue,
        StringBuilder returnValue,
        int size,
        string filePath);

        public iniManager(string filePath)
        {
            _filePath = filePath;
        }
    }
}
