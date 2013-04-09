using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class AccountInterestRateChange:AccountEvent
    {
        public AccountInterestRateChange(DateTime occurenceDate, decimal newInterestRate) 
        {
            this.OccuranceDate = occurenceDate;
            this.NewInterestRate = newInterestRate;
        }

        public decimal NewInterestRate { get; set; }
    }
}
