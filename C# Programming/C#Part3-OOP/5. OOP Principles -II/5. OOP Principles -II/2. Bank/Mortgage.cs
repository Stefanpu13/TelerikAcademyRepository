using System;
using System.Linq;


namespace _2.Bank
{
    public class Mortgage : Account, IDepositable
    {
        public Mortgage(Customer bankCustomer, DateTime dateOfCreation, decimal balance, decimal monthlyInterestRate) :
            base(bankCustomer, dateOfCreation,balance, monthlyInterestRate) 
        {
            this.Events.Add(InterestRateChangeResolver(bankCustomer));
        }

        

        public void DepositAmmount(decimal ammount, DateTime date)
        {
            this.Balance += ammount;
            AccountTransaction deposit = new AccountTransaction(date, ammount);           
            PutEventAtPosition(deposit);
        }

        protected override AccountEvent InterestRateChangeResolver(Customer bankCustomer)
        {
            if (bankCustomer is Individual)
            {
                return new AccountInterestRateChange(this.StartingDate.AddMonths(6), 0);
            }

            else if (bankCustomer is Company)
            {
                return new AccountInterestRateChange(this.StartingDate.AddMonths(12), this.MonthlyInterestRate / 2);
            }

            else
            {
                throw new ArgumentException("Customer must be Individual or Company");
            }
        }        
    }
}
