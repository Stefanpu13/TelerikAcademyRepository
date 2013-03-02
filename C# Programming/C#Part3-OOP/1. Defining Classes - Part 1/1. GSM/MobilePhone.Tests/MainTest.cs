using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.Tests
{
    class MainTest
    {
        static void Main() 
        {
            Console.Title = "Test Console";

            
            Console.WriteLine("---------------------GSMTest--------------------\n\n");
            GSMTest.PerformGSMTest();

            Console.WriteLine("---------------------------------------------\n\n");
            
            Console.WriteLine("\n-----------------GSMCallHistoryTest--------------------\n\n");
            GSMCallHistoryTest.PerformGSMCallHistoryTest();
        }
    }
}
