using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monitor
{
    
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ChekerString chekerString = new ChekerString(args);
            if (chekerString.IsAllOk)
            {
                TimerStarters timerStarters = new TimerStarters(chekerString.ProcessN, chekerString.WaitingT, chekerString.CheckT);
                timerStarters.TimerStarter();
            }
            File.WriteAllLines("logInfoFile.txt", LogFileCreator.ToStrintgArray());
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
