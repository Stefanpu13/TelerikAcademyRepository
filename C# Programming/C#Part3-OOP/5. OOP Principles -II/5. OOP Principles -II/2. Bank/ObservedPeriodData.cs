using System;
using System.Linq;


namespace _2.Bank
{
    /// <summary>
    /// A struct holding account information for an observed period. 
    /// </summary>
    struct ObservedPeriodData
    {

        public ObservedPeriodData(int startIndex, int endIndex, decimal initialAmmoumt,
            DateTime startDate,DateTime endDate, decimal currentInterestRate):this()
            
        {
            this.CurrentStartIndex = startIndex;
            this.CurrentEndIndex = startIndex;
            this.EndIndex = endIndex;
            this.InitialAmmount = initialAmmoumt;
            this.CurrentAmmount = initialAmmoumt;
            this.CurrentEndDate = startDate;
            this.CurrentStartDate = startDate;
            this.CurrentInterestRate = currentInterestRate;
            this.EndDate = endDate;
        }

        /// <summary>
        /// The index of the last transaction that occurs before the START date of a given
        /// subperiod in the observed period.
        /// </summary>
        public int CurrentStartIndex{get; set;}

        /// <summary>
        /// The index of the last transaction that occurs before the END date of a given
        /// subperiod in the observed period.
        /// </summary>
        public int CurrentEndIndex { get; set; }

        public int EndIndex { get; set; }

        public decimal InitialAmmount { get; set; }

        public decimal CurrentAmmount { get; set; }

        /// <summary>
        /// The start date of the current subperiod. Determined either by date of next transaction
        /// or by end date of whole period.  
        /// </summary>
        public DateTime CurrentEndDate { get; set; }

        /// <summary>
        /// The start date of the current subperiod. Determined either by start date of 
        /// whole period or by date of current transaction. 
        /// </summary>
        public DateTime CurrentStartDate { get; set; }

        /// <summary>
        /// The end date of the observed period.
        /// </summary>
        public DateTime EndDate { get; set; }

        public decimal CurrentInterestRate { get; set; }

        
    }
}
