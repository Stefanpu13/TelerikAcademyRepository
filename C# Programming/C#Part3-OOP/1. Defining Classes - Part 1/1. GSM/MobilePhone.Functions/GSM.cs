using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MobilePhone.Functions
{
    public class GSM
    {
        //private string model;
        //private string manufacturer;
        private decimal? price;
        //private string owner;
        //private Battery gsmBattery;
        //private Display gsmDisplay;
        private static  GSM iPhone4S ;
        private List<Call> callHistory = new List<Call>();


      

        static GSM() 
        {
            iPhone4S = new GSM("IPhone4s", "Apple", 199, "Ivan",
                    new Battery(BatteryType.LiIon, 0, 0), new Display(40, 60, 256000));
        }

        public GSM(string model, string manufacturer, decimal? price,
            string owner, Battery battery, Display display)
        {
            try
            {
                this.Model = model;
                this.Manufacturer = manufacturer;
                this.Price = price;

                //I want to initialise these two properties even if "Price" throws exception.
                //Not sure if this is the proper way. I chose "finally" block because
                //I think this will make my intensions clear - initialise these
                //properties in any case

                this.GsmBattery = battery;
                this.GsmDisplay = display;
                

            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine(aore.Message + "\n");
                Console.WriteLine(aore.ParamName + " set to 0.");
            }
            finally 
            {
                this.GsmBattery = battery;
                this.GsmDisplay = display;
            }
            
        }

        public GSM(string model, string manufacturer, decimal? price,
            string owner, Battery battery)
            : this(model, manufacturer, price, owner, battery, null) { }

        public GSM(string model, string manufacturer, decimal? price,
            string owner)
            : this(model, manufacturer, price, owner, null) { }

        public GSM(string model, string manufacturer, decimal? price)
            : this(model, manufacturer, price, null) { }

        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null) { }


        public static GSM IPhone4S
        {
            get{ return iPhone4S;}
        }


        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public decimal? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <0)
                {
                    this.price = 0;
                    throw new ArgumentOutOfRangeException
                        ("_Price", value, "Price can not be a negative number");
                }
                this.price = value;
            }
        }

        public string Owner { get; set; }

        public Battery GsmBattery { get; set; }

        public Display GsmDisplay { get; set; }

        public List<Call> CallHistory { get; set; }

        public void AddCall(Call call) 
        {
            if (call != null)
            {
                if (CallHistory != null)
                {
                    if (!CallHistory.Contains(call))
                    {
                        CallHistory.Add(call);
                    }
                    else
                    {
                        //This way I avoid entering the same call twice
                        throw new InvalidOperationException("Call is already added");
                    }
                }

                else
                {
                    CallHistory = new List<Call>();
                    CallHistory.Add(call);
                }
            }
            else
            {
                throw new ArgumentNullException("call", "Call to add is null.");
            }            
        }
        
        public void DeleteCall(Call call) 
        {
            if (call!= null)
            {
                this.CallHistory.Remove(call);
            }
            else
            {
                throw new ArgumentNullException("call", "Call to remove is null.");
            }
      
        }

        public void ClearCallHistory() 
        {
            CallHistory.Clear();
        }

        public override string ToString()
        {
            Type thisType = this.GetType();
            // You must specify the Instance and Public flags to get the public
            //instance properties.
            //Note: if take the static IPhone4S you get stackoverflow exception!!!
            PropertyInfo[] properties =
                thisType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            StringBuilder phoneInfo = new StringBuilder();

            phoneInfo.AppendLine("/-----Phone Info-----/\n");
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(this) ?? "null";
                phoneInfo.AppendLine(property.Name + ": " + propertyValue);
            }
            phoneInfo.AppendLine("/-------------------/");

            return phoneInfo.ToString();
        }

        public decimal? CalculateCallsPrice(decimal callPrise)
        {
            decimal? totalPrice = 0;

            if (CallHistory != null)
            {
                foreach (var call in CallHistory)
                {
                    totalPrice += (call.Duration * callPrise);
                }
            }

            //Price is per minute and calls are in seconds.
            return totalPrice /60;
        }
    }
}
