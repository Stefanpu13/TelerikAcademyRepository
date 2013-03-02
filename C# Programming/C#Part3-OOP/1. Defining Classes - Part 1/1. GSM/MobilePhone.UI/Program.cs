using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using MobilePhone.Functions;

namespace MobilePhone.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "UI Console";
            BatteryType nokiaBattery = BatteryType.LiIon;

            GSM nokia =
            new GSM("Nokia 6164", "Nokia", -3, null, new Battery(nokiaBattery, -4, -4),
                new Display(12, -12, -256));

            Console.WriteLine("\nNokia Info: ");
            Console.WriteLine(nokia);            
            Console.WriteLine(GSM.IPhone4S);
            nokia.CallHistory = new List<Call>();


            Call firstCall = new Call(new DateTime(2013,02,22,22,22,22), 878, 23424);  
            Call secondCall = new Call(new DateTime(2013, 02, 22, 22, 22, 22), 878, 23424);


            try
            {
                nokia.AddCall(firstCall);
                Console.WriteLine("\nCall added:\n");
                Console.WriteLine(firstCall);
                
                nokia.AddCall(secondCall);
                Console.WriteLine("\nCall added:\n");
                Console.WriteLine(secondCall);


            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message + "\n");
            }
            

            

            ////1. Create an array of few GSM objects
            //GSM nokiaC5 = new GSM("NokiaC5", "Nokia Inc", 250, null,
            //    new Battery(BatteryType.LiIon, 0, 1), new Display(240, 320, 16000000));
            ////GSM motorolaMotoluxe = new GSM("MotorolaMotoluxe", "Mototrola", 450, "Federer",
            ////    new Battery(BatteryType.LiIon, 0), new Display(480, 854, 43));
            ////GSM samsungAtivS = new GSM("SamsungAtviS", "Samsung", 1000, "Michael Jordan",
            ////    new Battery(BatteryType.LiIon, 4, 8), new Display(555, 867, 144));


            ////GSM[] gsmArray = { nokiaC5, motorolaMotoluxe, samsungAtivS };

            ////foreach (var gsm in gsmArray)
            ////{
            ////    Console.WriteLine(gsm);
            ////}

            ////Console.WriteLine(GSM.IPhone4S);

            

            //nokiaC5.AddCall(new Call(new DateTime(2013, 02, 20, 21, 06, 21), 08898898, 200));
            //nokiaC5.AddCall(new Call(new DateTime(2013, 01, 24, 14, 44, 21), 0898544321, 115));
            //nokiaC5.AddCall(new Call(new DateTime(2012, 12, 28, 16, 54, 44), 5554665, 144));

            //foreach (var call in nokiaC5.CallHistory)
            //{
            //    Console.WriteLine(call);                
            //}

            //decimal? totalPrice = nokiaC5.CalculateCallsPrice(0.37m);
            //Console.WriteLine("Total price is: " + totalPrice);

            //Call longestCall =nokiaC5.CallHistory.Find
            //    ( y => y.Duration== nokiaC5.CallHistory.Max(x => x.Duration));

            

            //nokiaC5.DeleteCall(longestCall);

            //foreach (var call in nokiaC5.CallHistory)
            //{
            //    Console.WriteLine(call);
            //}

            //totalPrice = nokiaC5.CalculateCallsPrice(0.37m);
            //Console.WriteLine("Total price is: " + totalPrice);

        }
    }
}
