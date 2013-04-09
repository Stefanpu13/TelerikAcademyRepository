using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace ExecuteAtInterval
{
    delegate void MethodDelegate();

    class Timer
    {
        public static void ExecuteMethodAtInterval(int intervalInSeconds)
        {
            Stopwatch timer = new Stopwatch();
            MethodDelegate executeInInterval = ConsoleWritingClass.PrintCurrentExecutionNumber;
            int intervalInMiliseconds = 1000 * intervalInSeconds;

            timer.Start();
            while (ConsoleWritingClass.ExecutionCounter <= 5)
            {
                if (timer.ElapsedMilliseconds == intervalInMiliseconds)
                {
                    executeInInterval();
                    timer.Restart();
                }
            }
        }
    }
}
