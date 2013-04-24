namespace Class123
{
    using System;

    class MainClass
    {
        //const int max_count = 6;
        class Printer
        {
            public void PrintBoolValueAsString(bool boolValue)
            {
                string boolValueAsString = boolValue.ToString();
                Console.WriteLine(boolValueAsString);
            }
        }

        public static void Main()
        {
            MainClass.Printer boolPrinter = new MainClass.Printer();
            boolPrinter.PrintBoolValueAsString(true);
        }
    }
}
