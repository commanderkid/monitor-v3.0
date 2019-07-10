using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace monitor
{
    static class Loop
    {
        static int Loops = 0;
        public static bool LoopChecker(int Loops, string ProcessName)
        {
            LogFileCreator.AddLine($"Info: Loop {Loops} has started");
            Loops++;
            int procLeft = Process.GetProcessesByName(ProcessName).Length;
            if (procLeft == 0)
            {
                LogFileCreator.AddLine($"Info: Killing processes for {ProcessName} has stoped");
                LogFileCreator.AddLine($"Info: Looping process has stoped");
                LogFileCreator.AddLine($"Info: All processes {ProcessName} has been finished");
                Console.WriteLine($"All processes {ProcessName} has been finished");
                return false;
            }
            else
            {
                Console.WriteLine($"Number of unclosed processes: {ProcessName} - {procLeft}");
                LogFileCreator.AddLine($"Info: Number of unclosed processes: {ProcessName} - {procLeft}");
                return true;
            }
        }
    }
}
