using System;
using System.Text;

namespace monitor
{
    static class LogFileCreator
    {
        static StringBuilder strBuilder = new StringBuilder();


        public static void AddLine(string line)
        {
            DateTimeOffset dateOffsetValue = DateTimeOffset.Now;
            strBuilder.Append(dateOffsetValue.ToString("hh: mm:ss.fff tt") + " " + line + "\n");
        }

        public static string[] ToStrintgArray()
        {
            return strBuilder.ToString().Split('\n');
        }
    }
}
