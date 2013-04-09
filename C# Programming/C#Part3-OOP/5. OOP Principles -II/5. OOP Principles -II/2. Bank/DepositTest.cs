using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class DepositTest
    {
        internal static void DepositMainTest(Individual ivan, DateTime creationDate, DateTime endDate)
        {

            Deposit individualDeposit = new Deposit(ivan, creationDate, 300, 0.005m);

            Console.WriteLine("DEPOSIT\n\n");

            DepositTest.SimpleDepositDefault(creationDate, endDate, individualDeposit);

            Console.WriteLine("-------------------");

            individualDeposit = new Deposit(ivan, creationDate, 300, 0.005m);
            DepositTest.SimpleDepositNonDefault(creationDate, endDate, individualDeposit);

            Console.WriteLine("-------------------");

            individualDeposit = new Deposit(ivan, creationDate, 300, 0.005m);
            DepositTest.OneTransactionDepositDefault(creationDate, endDate, individualDeposit);

            Console.WriteLine("-------------------");

            individualDeposit = new Deposit(ivan, creationDate, 300, 0.005m);
            DepositTest.OneTransactionDepositNonDefault(creationDate, endDate, individualDeposit);

            Console.WriteLine("-------------------");

            individualDeposit = new Deposit(ivan, creationDate, 300, 0.005m);
            DepositTest.TwoTransactionsDepositNonDefault(creationDate, endDate, individualDeposit);
        }

        private static void TwoTransactionsDepositNonDefault
            (DateTime creationDate, DateTime endDate, Deposit individualDeposit)
        {
            Console.WriteLine("Non default deposit with two transactions.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Add two deposit transations: first is \"Deposit\" of value 1700(to make 2000) at the second" +
              " month of the period. Second is \"Withdraww\" of value 1000 at 4th month of period.");
            Console.ResetColor();
            Console.WriteLine("Expected interest: 30");

            individualDeposit.DepositAmmount(1700, creationDate.AddMonths(2));
            individualDeposit.WithdrawAmmount(1000, creationDate.AddMonths(4));

            DisplayConditions(individualDeposit, creationDate, endDate, false);

            decimal oneTransactionInterest =
                individualDeposit.CalculateInterestAmmount(creationDate, endDate, false);


            Console.WriteLine("Total interest: " + oneTransactionInterest);
        }

        private static void OneTransactionDepositNonDefault
            (DateTime creationDate, DateTime endDate, Deposit individualDeposit)
        {
            Console.WriteLine("Non default deposit with one transaction.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Add one deposit trasation of value 1700(to make 2000) at second" +
               " month of the period.");
            Console.ResetColor();
            Console.WriteLine("Expected interest: 40");

            individualDeposit.DepositAmmount(1700, creationDate.AddMonths(2));
            DisplayConditions(individualDeposit, creationDate, endDate, false);

            decimal oneTransactionInterest =
                individualDeposit.CalculateInterestAmmount(creationDate, endDate, false);


            Console.WriteLine("Total interest: " + oneTransactionInterest);
        }

        private static void SimpleDepositNonDefault
            (DateTime creationDate, DateTime endDate, Deposit individualDeposit)
        {
            Console.WriteLine("Non default simple deposit.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Since this is a deposit and its ammount is less than 1000 " +
              "no interest should be gained.");
            Console.ResetColor();
            Console.WriteLine("Expected interest: {0}", 0);

            DisplayConditions(individualDeposit, creationDate, endDate, false);

            decimal noTransactionsTotalInterest =
               individualDeposit.CalculateInterestAmmount(creationDate, endDate, false);

            Console.WriteLine("Total interest: " + noTransactionsTotalInterest);
        }

        private static void OneTransactionDepositDefault
            (DateTime creationDate, DateTime endDate, Deposit individualDeposit)
        {
            Console.WriteLine("Default deposit with one transaction.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Add one deposit trasation of value 1700(to make 2000) at the second" +
                " month of the period.");
            Console.WriteLine("\"Default\" option is chosen.");
            Console.ResetColor();
            Console.WriteLine("Expected interest: 3 + 40 ");

            individualDeposit.DepositAmmount(1700, creationDate.AddMonths(2));

            DisplayConditions(individualDeposit, creationDate, endDate, true);

            decimal oneTransactionInterest =
                individualDeposit.CalculateInterestAmmount(creationDate, endDate, true);


            Console.WriteLine("Total interest: " + oneTransactionInterest);
        }

        private static void SimpleDepositDefault
            (DateTime creationDate, DateTime endDate, Deposit individualDeposit)
        {
            Console.WriteLine("Default simple deposit.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Since this is a deposit and its ammount is less than 1000 " +
                "no interest should be gained.");
            Console.WriteLine("But as \"default\" option is chosen, some interest will be gained.");
            Console.ResetColor();
            Console.WriteLine("Expected interest: {0} (300* 6*0.005)", 9);

            DisplayConditions(individualDeposit, creationDate, endDate, true);

            decimal noTransactionsTotalInterest =
               individualDeposit.CalculateInterestAmmount(creationDate, endDate, true);

            Console.WriteLine("Total interest: " + noTransactionsTotalInterest);
        }

        private static void DisplayConditions
            (Account account, DateTime startDate, DateTime endDate, bool isDefault)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Period start date: {0:dd.MM.yyyy}", startDate);
            Console.WriteLine("Period end date: {0:dd.MM.yyyy}", endDate);
            Console.WriteLine("Account interest rate: {0}%", account.MonthlyInterestRate);
            Console.WriteLine("Account transactions count: {0}", account.Events.Count);
            Console.WriteLine("Account starting ammount: {0}", account.Balance);
            Console.WriteLine("Is default?: {0}", isDefault);
            Console.WriteLine("CustomerType: {0}",
                account.BankCustomer is Individual ? "Indicidual" : "Company");
            Console.ResetColor();
        }
    }
}
