using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class MortgageTest
    {
        public static void MortgageMainTestMethod(Individual ivan, DateTime creationDate, DateTime endDate, Company comp, Mortgage companyMortgage, Mortgage individualMortgage)
        {
            CompanyTestMethod(creationDate, endDate, comp, companyMortgage);

            IndividualTestMethod(creationDate, endDate, ivan, individualMortgage);
        }

        private static void IndividualTestMethod(DateTime creationDate, DateTime endDate, Individual ivan, Mortgage individualMortgage)
        {
            SimpleMortgageCompanyNonDefault(creationDate, endDate, individualMortgage);

            Console.WriteLine("-------------------");
            Console.WriteLine("Customer is Individual.");
            OneTransactionMortgageCompanyNonDefault(creationDate, endDate, individualMortgage);

            individualMortgage = new Mortgage(ivan, creationDate, 500, 0.005m);
            TwoTransactionMortgageCompanyNonDefault(creationDate, endDate, individualMortgage);

            individualMortgage = new Mortgage(ivan, creationDate, 500, 0.005m);

            ThreeTransactionMortgageCompanyNonDefault(creationDate, endDate, individualMortgage);

            Console.WriteLine("-------------------");
        }

        private static void CompanyTestMethod(DateTime creationDate, DateTime endDate, Company comp, Mortgage companyMortgage)
        {
            SimpleMortgageCompanyNonDefault(creationDate, endDate, companyMortgage);

            Console.WriteLine("-------------------");
            Console.WriteLine("Customer is Company.");
            OneTransactionMortgageCompanyNonDefault(creationDate, endDate, companyMortgage);

            companyMortgage = new Mortgage(comp, creationDate, 500, 0.005m);
            TwoTransactionMortgageCompanyNonDefault(creationDate, endDate, companyMortgage);

            companyMortgage = new Mortgage(comp, creationDate, 500, 0.005m);

            ThreeTransactionMortgageCompanyNonDefault(creationDate, endDate, companyMortgage);

            Console.WriteLine("-------------------");
        }

        private static void OneTransactionMortgageCompanyNonDefault(DateTime creationDate,
            DateTime endDate, Mortgage companyMortgage)
        {
            Console.WriteLine("Non default morgage with one transaction.");
            Console.WriteLine("Transaction is on sixth month.");

            DisplayConditions(companyMortgage, creationDate, endDate, false);

            companyMortgage.DepositAmmount(500, creationDate.AddMonths(6));
            decimal noTransactionsTotalInterest =
               companyMortgage.CalculateInterestAmmount(creationDate, endDate, false);

            Console.WriteLine("Total interest: " + noTransactionsTotalInterest);
        }

        private static void TwoTransactionMortgageCompanyNonDefault(DateTime creationDate,
            DateTime endDate, Mortgage companyMortgage)
        {
            Console.WriteLine("Non default morgage with two transactions -" +
                " one before, and one after the end of special period.");

            DisplayConditions(companyMortgage, creationDate, endDate, false);

            companyMortgage.DepositAmmount(500, creationDate.AddMonths(6));
            companyMortgage.DepositAmmount(1000, creationDate.AddMonths(12));

            decimal noTransactionsTotalInterest =
               companyMortgage.CalculateInterestAmmount(creationDate, endDate, false);

            Console.WriteLine("Total interest: " + noTransactionsTotalInterest);
        }

        private static void ThreeTransactionMortgageCompanyNonDefault(DateTime creationDate,
            DateTime endDate, Mortgage companyMortgage)
        {
            Console.WriteLine("Non default morgage with three transactions -" +
                " two before, and one after the end of special period.");

            DisplayConditions(companyMortgage, creationDate, endDate, false);

            companyMortgage.DepositAmmount(500, creationDate.AddMonths(6));
            companyMortgage.DepositAmmount(500, creationDate.AddMonths(9));
            companyMortgage.DepositAmmount(500, creationDate.AddMonths(15));

            decimal noTransactionsTotalInterest =
               companyMortgage.CalculateInterestAmmount(creationDate, endDate, false);

            Console.WriteLine("Total interest: " + noTransactionsTotalInterest);
        }

        private static void DisplayConditions
            (Account account, DateTime startDate, DateTime endDate, bool isDefault)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Period start date: {0:dd.MM.yyyy}", startDate);
            Console.WriteLine("Period end date: {0:dd.MM.yyyy}", endDate);
            Console.WriteLine("Account interest rate: {0}%", account.MonthlyInterestRate);            
            Console.WriteLine("Account starting ammount: {0}", account.Balance);
            Console.WriteLine("Is default?: {0}", isDefault);
            Console.WriteLine("CustomerType: {0}",
                account.BankCustomer is Individual ? "Indicidual" : "Company");
            Console.ResetColor();
        }

        private static void SimpleMortgageCompanyNonDefault
            (DateTime creationDate, DateTime endDate, Mortgage companyMortgage)
        {
            Console.WriteLine("Non default simple morgage.");

            DisplayConditions(companyMortgage, creationDate, endDate, false);

            decimal noTransactionsTotalInterest =
               companyMortgage.CalculateInterestAmmount(creationDate, endDate, false);

            Console.WriteLine("Total interest: " + noTransactionsTotalInterest);
        }
    }
}
