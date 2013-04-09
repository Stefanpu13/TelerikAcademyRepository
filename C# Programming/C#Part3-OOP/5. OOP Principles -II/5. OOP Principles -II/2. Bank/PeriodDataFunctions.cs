using System;
using System.Collections.Generic;
using System.Linq;


namespace _2.Bank
{
    public class PeriodDataFunctions
    {
        internal static void DetermineNextStartDate(ref ObservedPeriodData periodData, int transactionIndex)
        {
            if (transactionIndex <= periodData.EndIndex)
            {
                periodData.CurrentStartDate = periodData.CurrentEndDate;
            }
        }

        internal static void DetermineCurrentAmount(Account account, ref ObservedPeriodData periodData, int transactionIndex)
        {
            if (transactionIndex < periodData.EndIndex)
            {
                if (account.Events[transactionIndex + 1] is AccountTransaction)
                {
                    periodData.CurrentAmmount += account.Events[transactionIndex + 1].Ammount;
                }                
            }
        }

        protected static decimal GetAccountAmmountAtStartOfPeriod(DateTime date, Account account)
        {
            decimal ammount = account.Events[0].Ammount;

            for (int i = 1; i < account.Events.Count - 1; i++)
            {
                if (account.Events[i].OccuranceDate < date && account.Events[i] is AccountTransaction)
                {
                    ammount += account.Events[i].Ammount;
                }
                else
                {
                    break;
                }
            }
            return ammount;
        }

        /// <summary>
        /// Gets the position of the last transaction that occured before a given date.  
        /// </summary>
        /// <param name="date">The start date of the observed period. </param>
        /// <param name="accountEvents">The list of transactions for the given account. </param>
        /// <returns>The index of the last transaction that occured before a given date.</returns>        
        protected static int GetTransactionBeforeDateIndex
            (DateTime date, List<AccountEvent> accountEvents)
        {
            for (int i = 0; i < accountEvents.Count - 1; i++)
            {
                if (accountEvents[i].OccuranceDate <= date && accountEvents[i + 1].OccuranceDate > date)
                {
                    return i;
                }
            }
            return accountEvents.Count - 1;
        }

        internal static ObservedPeriodData InitialisePeriodData
            (DateTime startDate, DateTime endDate, Account account)
        {
            // Get position of the events that last occured before tne start date
            // and the end date of the period.
            int startTransactionIndex =
                GetTransactionBeforeDateIndex(startDate, account.Events);
            int endTransactionIndex =
                GetTransactionBeforeDateIndex(endDate, account.Events);

            // The ammount in the account at the start of the inspected period.
            decimal initialAmmount = GetAccountAmmountAtStartOfPeriod(startDate, account);
            decimal currentInterestRate = account.MonthlyInterestRate;

            // A struct holding important data for an account whose period interest will be 
            // caclulated.
            ObservedPeriodData periodData = new ObservedPeriodData
                (startTransactionIndex, endTransactionIndex, initialAmmount, startDate, endDate,
                currentInterestRate);
            return periodData;
        }

        /// <summary>
        /// Determines the current subperiod end date. 
        /// </summary>
        /// <param name="account">Observed account. </param>
        /// <param name="periodData">The data in the account for the observed period. </param>
        /// <param name="transactionIndex">The index of the transaction that starts
        /// the current subperiod. </param>
        /// <returns></returns>
        internal static ObservedPeriodData DetermineNextEndDate
            (Account account, ObservedPeriodData periodData, int transactionIndex)
        {
            //If there are any transactions in the whole period then next transaction`s start date
            // is made the end date of the current subperiod.
            if (transactionIndex < periodData.EndIndex)
            {

                periodData.CurrentEndDate =
                account.Events[transactionIndex + 1].OccuranceDate;
            }
            else
            {
                // If no more transactions in the period, then next date is the end of the period.
                periodData.CurrentEndDate =
                periodData.EndDate;
            }
            return periodData;
        }

        internal static ObservedPeriodData DetermineNextEndDate
           (Account account, ref ObservedPeriodData periodData,
            AccountInterestRateChange interestChangeEvent, int transactionIndex)
        {
            // If this transaction is before the end of the special period.
            if (account.Events[transactionIndex].OccuranceDate <
                interestChangeEvent.OccuranceDate)
            {
                // If this is not the last transaction in the observed period.
                if (transactionIndex < periodData.EndIndex)
                {
                    // If next transaction is also before end of special period.
                    if (account.Events[transactionIndex + 1].OccuranceDate <
                    interestChangeEvent.OccuranceDate)
                    {
                        periodData.CurrentEndDate =
                            account.Events[transactionIndex + 1].OccuranceDate;
                    }
                    else
                    {
                        periodData.CurrentEndDate = interestChangeEvent.OccuranceDate;
                    }
                }
                else
                {
                    periodData.CurrentEndDate = interestChangeEvent.OccuranceDate;
                }
            }
            else
            {
                // If this is not the last transaction in the observed period.
                if (transactionIndex < periodData.EndIndex)
                {
                    periodData.CurrentEndDate =
                            account.Events[transactionIndex + 1].OccuranceDate;
                }
                else
                {
                    periodData.CurrentEndDate = periodData.EndDate;
                }
            }
            return periodData;

        }
    }
}
