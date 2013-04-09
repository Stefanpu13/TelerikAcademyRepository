using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    public class AccountEvent
    {
        // This default constructor will be called in derived classes when their constructors'
        // signature does not match the base class` constructors.
        public AccountEvent() { }

        public AccountEvent(DateTime dateOfOccurence) 
        {
            this.OccuranceDate = dateOfOccurence;
        }

        public AccountEvent(DateTime dateOfOccurence, decimal ammount)
        {
            this.OccuranceDate = dateOfOccurence;
            this.Ammount = ammount;
        }
        internal DateTime OccuranceDate { get; set; }

        internal decimal Ammount { get; set; }
    }
}
