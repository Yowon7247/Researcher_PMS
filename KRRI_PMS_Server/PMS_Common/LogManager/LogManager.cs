using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PMS_Common.LogManager
{
    public static class LogManager
    {
        private static readonly Logger logger = new Logger();

        public static void Info(
            string project,
            string message,
            [CallerMemberName] string member = "",
            [CallerFilePath] string file = "")
        {
            logger.Write(LogLevel.Info, project, file, member, message);
        }

        public static void Error(
            string project,
            string message,
            [CallerMemberName] string member = "",
            [CallerFilePath] string file = "")
        {
            logger.Write(LogLevel.Error, project, file, member, message);
        }
    }
}
