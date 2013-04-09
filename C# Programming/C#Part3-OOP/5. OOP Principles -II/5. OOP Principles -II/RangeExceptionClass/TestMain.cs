using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeExceptionClass
{
    class TestMain
    {
        static void Main(string[] args)
        {
            //ExceptionTestingApp<int> intTest = new ExceptionTestingApp<int>(0, 100);

            //try
            //{
            //    while (true)
            //    {
            //      int value =  intTest.EnterValue<int>();
            //    }
            //}
            //catch (InvalidRangeException<int> Iea)
            //{

            //    Console.WriteLine(Iea.Message);
            //    Console.WriteLine(Iea.ValidRange);
            //}



            DateTime minDateTime = new DateTime(1980, 1,1);
            DateTime maxDateTime = new DateTime(2013,12,31);


            ExceptionTestingApp<DateTime> dateTimeTest =
                new ExceptionTestingApp<DateTime>(minDateTime, maxDateTime);

            try
            {
                while (true)
                {
                    DateTime  valueDate = dateTimeTest.EnterValue<DateTime>();
                }
            }
            catch (InvalidRangeException<DateTime> Iea)
            {

                Console.WriteLine(Iea.Message);
                Console.WriteLine(Iea.ValidRange);
            }
        }
    }
}
