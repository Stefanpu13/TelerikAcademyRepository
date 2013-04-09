using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class InterestCalculator
    {
        private static decimal CalculateInterestInPeriod(DateTime startDate,
            DateTime endDate, decimal currentAmmount, decimal currentInterestRate)
        {
            int months = (int)(endDate - startDate).TotalDays / 30;
            decimal interest = currentInterestRate* currentAmmount * months;
            return interest;
        }

        public static decimal InterestCaclulation
            (DateTime startDate, DateTime endDate, Account account, bool isDefault)
        {
            ObservedPeriodData periodData = PeriodDataFunctions.
                InitialisePeriodData(startDate, endDate, account);
            decimal totalInterest = 0;

            if (isDefault)
            {
                totalInterest = DefaultInterestCalculation(account, periodData);
            }
            else
            {
               totalInterest = ResolveCalculationMethod(account, ref periodData);
            }
            return totalInterest;

        }

        private static decimal ResolveCalculationMethod(Account account, ref ObservedPeriodData periodData)
        {
            decimal totalInterest = 0;

            if (account is Deposit)
            {
                totalInterest = DepositInterestCalculation(account, periodData);
            }

            if (account is Loan)
            {

                totalInterest = MortgageInterestCalculation(account, periodData);
                
            }

            if (account is Mortgage)
            {
                totalInterest = MortgageInterestCalculation(account, periodData);
            }

            return totalInterest;
        }
  
        private static decimal DefaultInterestCalculation
            (Account account, ObservedPeriodData periodData)
        {
            decimal totalInterest = 0;
            periodData.CurrentInterestRate = Account.DefaultInterestRate;

            // Taking into account each of the transactions` data, caclulate total interest.
            for (int transactionIndex = periodData.CurrentStartIndex;
                    transactionIndex <= periodData.EndIndex; transactionIndex++)
            {

                periodData =PeriodDataFunctions.DetermineNextEndDate(account, periodData, transactionIndex);
                totalInterest = AppendTotalInterest(account, ref periodData,
                    totalInterest, transactionIndex);

               PeriodDataFunctions.DetermineCurrentAmount(account, ref periodData, transactionIndex);
               PeriodDataFunctions.DetermineNextStartDate(ref periodData, transactionIndex);
            }
            return totalInterest;
        }

        private static decimal MortgageInterestCalculation(Account account,
        ObservedPeriodData periodData)
        {
            decimal totalInterest = 0;
            AccountInterestRateChange interestRateChangeEvent =
                (AccountInterestRateChange)account.Events.Find(x => x is AccountInterestRateChange);

            for (int transactionIndex = periodData.CurrentStartIndex;
                    transactionIndex <= periodData.EndIndex; transactionIndex++)
            {
                if (account is Deposit)
                {
                    ResolveDepositInterestRate(account, ref periodData);
                }
                else
                {
                    ResolveMortgageAndLoanInterestRate
                    (account,ref periodData, interestRateChangeEvent);
                }                

                periodData = PeriodDataFunctions.DetermineNextEndDate(account, ref periodData,
                    interestRateChangeEvent, transactionIndex);

                totalInterest = AppendTotalInterest(account, ref periodData,
                    totalInterest, transactionIndex);

                PeriodDataFunctions.DetermineCurrentAmount(account, ref periodData, transactionIndex);
                PeriodDataFunctions.DetermineNextStartDate(ref periodData, transactionIndex);
            }
            return totalInterest;

        }

        private static void ResolveMortgageAndLoanInterestRate(Account account, ref ObservedPeriodData periodData, AccountInterestRateChange interestRateChangeEvent)
        {
            if (periodData.CurrentStartDate < interestRateChangeEvent.OccuranceDate)
            {
                periodData.CurrentInterestRate = interestRateChangeEvent.NewInterestRate;
            }
            else
            {
                periodData.CurrentInterestRate = account.MonthlyInterestRate;
            }            
        }

        private static decimal LoanInterestCaclulation
            (Account account, ObservedPeriodData periodData, int months)
        {
            decimal totalInterest = 0;

            for (int transactionIndex = periodData.CurrentStartIndex;
                    transactionIndex <= periodData.CurrentEndIndex; transactionIndex++)
            {

                if (periodData.CurrentStartDate <= account.StartingDate.AddMonths(months))
                {
                    periodData.CurrentInterestRate = 0;
                    //periodData.EndDate = account.StartingDate.AddMonths(months);
                }
                else
                {
                    periodData.CurrentInterestRate = account.MonthlyInterestRate;
                }

                periodData = PeriodDataFunctions.DetermineNextEndDate(account, periodData, transactionIndex);  
                totalInterest = AppendTotalInterest(account, ref periodData,
                    totalInterest, transactionIndex);

                PeriodDataFunctions.DetermineCurrentAmount(account, ref periodData, transactionIndex);
                PeriodDataFunctions.DetermineNextStartDate(ref periodData, transactionIndex);
            }

            return totalInterest;
        }

        private static decimal DepositInterestCalculation
            (Account account, ObservedPeriodData periodData)
        {
            decimal totalInterest = 0;

            // Taking into account each of the transactions` data, caclulate total interest.
            for (int transactionIndex = periodData.CurrentStartIndex;
                    transactionIndex <= periodData.EndIndex; transactionIndex++)
            {
                ResolveDepositInterestRate(account,ref periodData);

                periodData =PeriodDataFunctions.DetermineNextEndDate(account, periodData, transactionIndex);                
                totalInterest = AppendTotalInterest(account, ref periodData,
                    totalInterest, transactionIndex);

                PeriodDataFunctions.DetermineCurrentAmount(account, ref periodData, transactionIndex);
                PeriodDataFunctions.DetermineNextStartDate(ref periodData, transactionIndex);
            }

            return totalInterest;
        }

        private static void ResolveDepositInterestRate(Account account,ref ObservedPeriodData periodData)
        {
            if (periodData.CurrentAmmount >= 0 && periodData.CurrentAmmount < 1000)
            {
                periodData.CurrentInterestRate = 0;
            }
            else
            {
                periodData.CurrentInterestRate = account.MonthlyInterestRate;
            }
        }

        /// <summary>
        /// Appends the interest acculmulated for a given period to the total interest.
        /// </summary>
        /// <param name="account">The observed account.</param>
        /// <param name="periodData">The account data for the given period.</param>
        /// <param name="totalInterest">The currently accumulated interest.</param>
        /// <param name="transactionIndex">The index of the current transaction in 
        /// the current subperiod.</param>
        /// <returns></returns>
        private static decimal AppendTotalInterest
            (Account account, ref ObservedPeriodData periodData,
            decimal totalInterest, int transactionIndex)
        {
            totalInterest += CalculateInterestInPeriod
                (periodData.CurrentStartDate, periodData.CurrentEndDate,
                periodData.CurrentAmmount, periodData.CurrentInterestRate);

            return totalInterest;
        }
    }
}
