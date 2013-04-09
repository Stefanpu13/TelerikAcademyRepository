using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteAtInterval
{
    class ConsoleWritingClass
    {
        private static int executionCounter = 1;

        public static int ExecutionCounter
        {
            get
            {
                return executionCounter;
            }
            set
            {
                executionCounter = value;
            }
        }

        public static void PrintCurrentExecutionNumber() 
        {
            Console.WriteLine("Method executed {0} times", executionCounter++);
        }
    }
}
