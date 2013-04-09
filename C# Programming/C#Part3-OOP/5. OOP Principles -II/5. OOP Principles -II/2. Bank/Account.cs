using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    public abstract class Account
    {

        protected Account(Customer bankCustomer,DateTime dateOfCreation, 
            decimal balance, decimal montlyIntersestRate) 
        {
            this.BankCustomer = bankCustomer;
            this.Balance = balance;
            this.MonthlyInterestRate = montlyIntersestRate;
            this.Events = new List<AccountEvent>()
            { new AccountTransaction(dateOfCreation, balance) };            
            this.StartingDate = dateOfCreation;
        }

        protected Account(Customer bankCustomer,DateTime dateOfCreation ,decimal balance) :
            this(bankCustomer,dateOfCreation ,balance, DefaultInterestRate) { }

        //If account has not interest rate set then this default rate is used
        internal static decimal DefaultInterestRate { get { return 0.06m / 12m; } }        

        public DateTime StartingDate { get; set; }

        public Customer BankCustomer { get; set; }
        
        public decimal Balance { get; set; }

        public decimal MonthlyInterestRate { get; set; }

        public List<AccountEvent> Events { get; set; }

        // Since there is common case in the task given the method should be declared virtual
        public virtual decimal CalculateInterestAmmount(DateTime startDate, DateTime endDate, bool isDefault) 
        {
            //Logic Of calculation put in a different place.
            return InterestCalculator.InterestCaclulation(startDate, endDate, this, isDefault);
        }

        protected void PutEventAtPosition(AccountTransaction deposit)
        {
            bool eventInserted = false;

            for (int currentEventindex = 1; currentEventindex < this.Events.Count; currentEventindex++)
            {
                if (this.Events[currentEventindex].OccuranceDate > deposit.OccuranceDate)
                {
                    this.Events.Insert(currentEventindex, deposit);
                    eventInserted = true;
                    break;
                }
            }

            if (!eventInserted)
            {
                this.Events.Add(deposit);
            }
        }

        protected virtual AccountEvent InterestRateChangeResolver(Customer bankCustomer)
        {
            return this.Events[0];
        }       
    }
}
