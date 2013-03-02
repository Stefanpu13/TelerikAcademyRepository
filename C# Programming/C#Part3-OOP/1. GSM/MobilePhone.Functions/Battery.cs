using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MobilePhone.Functions
{
    public enum BatteryType { LiIon, NiMN, NiCd, }

    public class Battery
    {
        private BatteryType? batteryModel;
        private double? idleHours;
        private double? hoursTalk;

        public Battery(BatteryType? batteryModel, double? idleHours, double? hoursTalk)
        {
            BatteryModel = batteryModel;

            try
            { 
                IdleHours = idleHours;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Console.WriteLine("Idle hours set to 0.\n");
            }

            try
            {
                HoursTalk = hoursTalk;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Console.WriteLine("Hours talk set to 0.\n");
            }           
        }

        public Battery(BatteryType? model, double idleHours) : this(model, idleHours, null) { }

        public Battery(BatteryType? model) : this(model, null, null) { }

        public Battery() : this(null) { }

        public BatteryType? BatteryModel
        {
            get { return this.batteryModel; }
            set { this.batteryModel = value; }
        }

        //Select the field "idleHours" and press Ctrl + R,E
        public double? IdleHours
        {
            get
            {
                return this.idleHours;
            }
            set
            {                 
                if (value < 0)
                {
                    this.idleHours = 0;
                    throw new ArgumentException("Negative idle hours entered");
                }
                else
                {
                    this.idleHours = value;
                }
                
            }
        }

        //Select "Refactor -> Encapsulate Field"
        public double? HoursTalk
        {
            get { return hoursTalk; }
            set
            {
                if (value < 0)
                {
                    this.hoursTalk = 0;
                    throw new ArgumentException("Negative hours talk entered");
                }
                else
                {
                    this.hoursTalk = value;                    
                }
            }
        }

        public override string ToString()
        {
            Type thisType = this.GetType();
            PropertyInfo[] properties = thisType.GetProperties();
            StringBuilder phoneInfo = new StringBuilder();

            phoneInfo.AppendLine();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(this) ?? "null";
                phoneInfo.AppendLine("\t" + property.Name + ": " + propertyValue);
            }

            return phoneInfo.ToString();
        }
    }
}
