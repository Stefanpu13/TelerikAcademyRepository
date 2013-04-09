using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ExecuteAtInterval
{
    /*Using delegates write a class Timer that has can execute certain method at each t seconds.

     */

    class MainClass
    {
        static void Main(string[] args)
        {
            Console.Write("Enter time interval in seconds: ");
            int seconds = int.Parse(Console.ReadLine());

            Timer.ExecuteMethodAtInterval(seconds);
        }
    }
}
