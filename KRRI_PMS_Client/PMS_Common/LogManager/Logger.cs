using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Common.LogManager
{
    public class Logger
    {
        private readonly string logFolder =
            Path.Combine(AppContext.BaseDirectory, "Log");

        public Logger()
        {
            Directory.CreateDirectory(logFolder);
        }

        public void Write(
            LogLevel level,
            string project,
            string file,
            string member,
            string message)
        {
            string className = Path.GetFileNameWithoutExtension(file);

            string log = string.Format(
                "[{0:yyyy-MM-dd HH:mm:ss.fff}] [{1}] [{2}] [{3}] [{4}] {5}",
                DateTime.Now,
                level,
                project,
                className,
                member,
                message);

            string fileName =
                DateTime.Now.ToString("yyyyMMdd") + ".log";

            File.AppendAllText(
                Path.Combine(logFolder, fileName),
                log + Environment.NewLine);
        }
    }
}
