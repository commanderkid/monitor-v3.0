using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace monitor
{
    static class KillingProcess
    {
        public static void StartClosing(string ProcessName)
        {
            LogFileCreator.AddLine($"Info: Looping process has stopped");
            Process[] prc = Process.GetProcessesByName(ProcessName);
            foreach (Process proc in prc)
            {
                try
                {
                    LogFileCreator.AddLine($"Info: Trying to kill process {proc.Id} {ProcessName}");
                    proc.Kill();
                    Thread.Sleep(3000);
                }
                catch
                {
                    Console.WriteLine($"Can't kill process: {proc.Id} {ProcessName}");
                    LogFileCreator.AddLine($"Error: Can't kill process: {proc.Id} {ProcessName}");
                }
            }
            int procLeng = Process.GetProcessesByName(ProcessName).Length;
            
            if (procLeng == 0)
            {
                Console.WriteLine($"All processes {ProcessName} has been killed");
                LogFileCreator.AddLine($"Info: All processes {ProcessName} has been killed");
            }
            else
            {
                Console.WriteLine($"Number of unclosed processes: {ProcessName} is {procLeng}");
                LogFileCreator.AddLine($"Info: Number of unclosed processes: {ProcessName} is {procLeng}");
            }
        }
    }
}
