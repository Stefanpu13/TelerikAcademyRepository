using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class Deposit : Account, IDepositable, IWithdrawable
    {
        public Deposit(Customer bankCustomer, DateTime dateOfCreation, decimal balance, decimal monthlyInterestRate) :
            base(bankCustomer, dateOfCreation, balance, monthlyInterestRate) { }

        public Deposit(Customer bankCustomer, DateTime dateOfCreation, decimal balance) :
            base(bankCustomer, dateOfCreation, balance) { }

        public void DepositAmmount(decimal ammount, DateTime date)
        {
            this.Balance += ammount;
            this.Events.Add(new AccountTransaction(date, ammount));
        }

        public void WithdrawAmmount(decimal ammount, DateTime date)
        {
            this.Balance -= ammount;
            this.Events.Add(new AccountTransaction(date, -ammount));
        }
    }
}
