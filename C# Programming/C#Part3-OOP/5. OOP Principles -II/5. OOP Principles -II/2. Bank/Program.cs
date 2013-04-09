using System;
using System.Linq;

namespace _2.Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Individual ivan = new Individual("Ivan Ianov", "Sofia, Slatina");
            DateTime creationDate = new DateTime(2012, 6, 15);
            DateTime endDate = creationDate.AddMonths(6);

            DepositTest.DepositMainTest(ivan, creationDate, endDate);

            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("--------------------------------------------------\n");

            Console.WriteLine("MORTGAGE\n\n");

            Company comp = new Company("LTSF", "Sofia");
            endDate = creationDate.AddMonths(18); 
            Mortgage companyMortgage = new Mortgage(comp, creationDate, 500, 0.005m);
            Mortgage individualMortgage = new Mortgage(ivan, creationDate, 500, 0.005m);

            MortgageTest.MortgageMainTestMethod(ivan, creationDate, endDate, comp, companyMortgage, individualMortgage);
        }
    }
}
