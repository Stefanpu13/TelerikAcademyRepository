using System;
using System.Linq;


namespace _2.Bank
{
    /*A strucy to hold info about  the transactions of the account */
    public class AccountTransaction:AccountEvent
    {
        public AccountTransaction(DateTime startDate) : base(startDate) { }

        public AccountTransaction(DateTime startDate, decimal ammount):base(startDate, ammount)
        {
            //this.OccuranceDate = startDate;
            //this.Ammount = ammount;
        }

        public decimal Ammount { get; set; }

        
    }
}
