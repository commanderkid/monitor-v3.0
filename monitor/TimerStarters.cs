using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Timers;
using System.Diagnostics;
using System.Threading.Tasks;

namespace monitor
{
    class TimerStarters
    {
        private string ProcessName;
        private int KillTime;
        private int WaitingTime;
        private bool timeToOut = true;
        private int COUNTER = 0;
        public TimerStarters(string procN, int killTime, int waitTime)
        {
            ProcessName = procN;
            KillTime = killTime;
            WaitingTime = waitTime;
        }

        public void TimerStarter()
        {
            while(timeToOut)
            {
                Thread.Sleep(1000);
                COUNTER += 1000;
                if(KillTime == 0 || COUNTER % KillTime == 0)
                {
                    KillingProcess.StartClosing(ProcessName);
                    break;
                }
                if(WaitingTime != 0 && COUNTER % WaitingTime == 0)
                    timeToOut = Loop.LoopChecker(COUNTER % WaitingTime, ProcessName);
            }
        }
    }
}
