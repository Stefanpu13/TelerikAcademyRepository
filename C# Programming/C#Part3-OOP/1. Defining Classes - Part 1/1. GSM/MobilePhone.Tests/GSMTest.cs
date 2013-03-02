using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhone.Functions;

namespace MobilePhone.Tests
{
    class GSMTest
    {
        public static void PerformGSMTest()
        {
            //1. Create an array of few GSM objects
            GSM nokiaC5 = new GSM("NokiaC5", "Nokia Inc", 250, null,
                new Battery(BatteryType.LiIon, 0, 1), new Display(240, 320, 16000000));
            GSM motorolaMotoluxe = new GSM("MotorolaMotoluxe", "Mototrola", 450, "Federer",
                new Battery(BatteryType.LiIon, 0), new Display(480, 854, 43));
            GSM samsungAtivS = new GSM("SamsungAtviS", "Samsung", 1000, "Michael Jordan",
                new Battery(BatteryType.LiIon, 4, 8), new Display(555, 867, 144));


            GSM[] gsmArray = { nokiaC5, motorolaMotoluxe, samsungAtivS };

            foreach (var gsm in gsmArray)
            {
                Console.WriteLine(gsm);
            }

            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
