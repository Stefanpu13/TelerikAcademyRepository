using System;
using System.Linq;


namespace _2.Bank
{
    class Loan: Account, IDepositable
    {
        public Loan(Customer bankCustomer, DateTime dateOfCreation, decimal balance, decimal monthlyInterestRate) :
            base(bankCustomer, dateOfCreation,balance, monthlyInterestRate) 
        {
            this.Events.Add(InterestRateChangeResolver(bankCustomer));
        }

        protected override AccountEvent InterestRateChangeResolver(Customer bankCustomer)
        {
            if (bankCustomer is Individual)
            {
                return new AccountInterestRateChange(this.StartingDate.AddMonths(3), 0);
            }
            else if (bankCustomer is Company)
            {
                return new AccountInterestRateChange(this.StartingDate.AddMonths(2),0);
            }
            else
            {
                throw new ArgumentException("Customer must be Individual or Company");
            }
        }

        public void DepositAmmount(decimal ammount, DateTime date)
        {
            this.Balance += ammount;
            AccountTransaction deposit = new AccountTransaction(date, ammount);
            PutEventAtPosition(deposit);
        }

    }
}
