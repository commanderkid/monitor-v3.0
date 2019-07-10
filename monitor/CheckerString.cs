using System;
using System.Diagnostics;

namespace monitor
{
    
    class ChekerString
    {
        public readonly int WaitingT, CheckT;
        public readonly string ProcessN;
        public readonly bool IsAllOk = false;

        public ChekerString(string[] args)
        {
            LogFileCreator.AddLine($"Program has started");

            if (args.Length != 3)
            {
                Console.WriteLine("Wrong input data! Must be: process_name(string) waiting_time(integer) checking_period(integer)");
                LogFileCreator.AddLine($"Warning: Wrong input length: {args.Length}, must be 3");
            }
            else if (!int.TryParse(args[1], out WaitingT))
            {
                Console.WriteLine("Wrong waiting_time input information");
                LogFileCreator.AddLine("Warning: Wrong waiting_time input information, must be number");
            }
            else if (!int.TryParse(args[2], out CheckT))
            {
                Console.WriteLine("Wrong checking_period input information");
                LogFileCreator.AddLine("Warning: Wrong checking_period input information, must be number");
            }
            else if (Process.GetProcessesByName(args[0]).Length == 0)
            {
                Console.WriteLine($"Process {args[0]} is not exist");
                LogFileCreator.AddLine($"Warning: Process {args[0]} is not exist");
            }
            else if ((WaitingT < 35791) && (CheckT < 35791))
            {
                LogFileCreator.AddLine($"Info: Input information: process_name: {args[0]}, waiting_time: {args[1]}, checking_time: {args[2]}");
                IsAllOk = true;
                WaitingT = WaitingT * 1000;
                CheckT = CheckT * 1000;


                #region Comment this region to turn minutes into seconds
                WaitingT = WaitingT * 60; 
                CheckT   = CheckT   * 60;
                #endregion

                ProcessN = args[0];
            }
            else
            {
                Console.WriteLine("waiting_time and check_time must be less or equal 35791");
                LogFileCreator.AddLine($"Warning: Waiting_time and check_time must be less or equal 35791");
            }
        }
    }
}
