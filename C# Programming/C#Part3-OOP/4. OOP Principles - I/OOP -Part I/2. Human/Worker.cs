using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace _2.Human
{
    public class Worker : Human
    {
        private decimal weeklySalary;
        private decimal workHoursPerDay;
        private decimal moneyPerHour;

        public Worker(string firstName, string lastName, decimal weeklySalary, decimal workHoursPerDay) :
            base(firstName, lastName)
        {            
            this.WeeklySalary = weeklySalary;
            this.WorkHoursPerDay = workHoursPerDay;
            this.moneyPerHour = this.MoneyPerHour();
        }

        public Worker(string firstName, string lastName) : base(firstName, lastName) { }

        private readonly int workingDaysPerWeek = 5;        
   

        public decimal WeeklySalary
        {
            get
            {
                return this.weeklySalary;
            }
            set
            {
                this.weeklySalary = value;
                this.moneyPerHour = this.MoneyPerHour();
            }
        }

        public decimal WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                this.workHoursPerDay = value;
                this.moneyPerHour = this.MoneyPerHour();
            }
        }

        public decimal MoneyPerHour()
        {
            if (this.weeklySalary!=0 && this.workHoursPerDay!=0)	
            {
                decimal moneyPerHour = this.weeklySalary / (this.workHoursPerDay * workingDaysPerWeek);
                return moneyPerHour;		 
            }
            else
	        {
                return 0;
	        } 
        }

        public override string ToString()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            NumberFormatInfo invariantNumberFormat = NumberFormatInfo.CurrentInfo;            
            
            StringBuilder workerInfo = new StringBuilder();

            workerInfo.Append("First name: " + this.FirstName + ", Last name: " + this.LastName +
                ", Money per hour: " + 
                this.moneyPerHour.ToString("#.##" + invariantNumberFormat.CurrencySymbol));

            return workerInfo.ToString();
        }
    }
}
