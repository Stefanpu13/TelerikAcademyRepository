using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhone.Functions;

namespace MobilePhone.Tests
{
    class GSMCallHistoryTest
    {
        public static void PerformGSMCallHistoryTest() 
        {
            GSM nokiaC5 = new GSM("NokiaC5", "Nokia Inc", 250, null,
                new Battery(BatteryType.LiIon, 0, 1), new Display(240, 320, 16000000));

            nokiaC5.AddCall(new Call(new DateTime(2013, 02, 20, 21, 06, 21), 08898898, 200));
            nokiaC5.AddCall(new Call(new DateTime(2013, 01, 24, 14, 44, 21), 0898544321, 115));
            nokiaC5.AddCall(new Call(new DateTime(2012, 12, 28, 16, 54, 44), 5554665, 144));

            //2. Display Info About the calls
            #region
            Console.WriteLine("Full Call history:\n");
            PrintCalls(nokiaC5);
            #endregion

            //3. Calculate total price.
            #region
            decimal? totalPrice = nokiaC5.CalculateCallsPrice(0.37m);
            Console.WriteLine("Total price is:{0:C2}", totalPrice);
            #endregion

            //4. Remove longest call.            
            //Note: If there are two calls with the same durartion, the earlier entered
            //will be deleted.
            #region
            //Find the y(call) SUCH THAT y(call).Duration == 
            //MaxElement(x which IS(BECOMES) Duration)
            Call longestCall = nokiaC5.CallHistory.Find
                (y => y.Duration == nokiaC5.CallHistory.Max(x => x.Duration));
            nokiaC5.DeleteCall(longestCall);

            Console.WriteLine("\nCall history after longest call deletion:\n");
            PrintCalls(nokiaC5);

            totalPrice = nokiaC5.CalculateCallsPrice(0.37m);
            Console.WriteLine("Total price is: {0:C2}", totalPrice);
            #endregion

            //5. Clear call history and print it.
            #region
            Console.WriteLine("\nClear call history\n");
            nokiaC5.ClearCallHistory();

            Console.WriteLine("Calls in call history: {0}", nokiaC5.CallHistory.Count);
            PrintCalls(nokiaC5);
            #endregion
        }

        private static void PrintCalls(GSM mobilePhone)
        {
            foreach (var call in mobilePhone.CallHistory)
            {
                Console.WriteLine(call);
            }
            Console.WriteLine();
        }

    }
}
