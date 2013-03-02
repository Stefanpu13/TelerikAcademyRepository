using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Globalization;
using System.Threading;

namespace MobilePhone.Functions
{
    public class Call
    {
        private DateTime date;
        private DateTime time;
        private int number;
        //No more than a few hours of talking possible
        private short duration;

        public Call(DateTime dateAndTime, int phoneNumber, short duration)
        {
            try
            {
                this.date = dateAndTime;
                this.time = dateAndTime;
                this.number = phoneNumber;
                this.duration = duration;
            }
            catch (ApplicationException appe)
            {
                Console.WriteLine(appe.Message + "/n");
            }

        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public DateTime Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }

        public int Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }

        public short Duration
        {
            get
            {
                return this.duration;
            }
            //Outside user can`t set duration.Reason? - After the end of a call 
            //user must not be able to change its duration. So only after a call is 
            //finished( or new "Call" object is created) its duration is set.
            private set
            {
                if (value < 0)
                {
                    //Note: As every exception in this task, I just want to try
                    //how they work and choose them on loose criteria.
                    //Here I desided that since in real situation Call is part of an application
                    //and the user does not input duration data, a negative duration is 
                    // a mistake of the app.
                    throw new ApplicationException("Aplication error occured. Call with negative" +
                        "duration was created");
                }
                else
                {
                    this.duration = value;
                }

            }
        }

        //This way I compare objects of type Call. So if I have two Calls with same
        //properties the objects  are considered equal
        //(though they might reference different objects)
        /*
         Example(pseudocode): 
         Call CallOne = new Call(today,13:00, 555 1hour )
         Call CallTwo = new Call(today,13:00, 555 1hour )
         CallOne == CallTwo? -> False
         Without this overrriding CallOne and CallTwo have the same properties
         but point to different objects and are not equal
          
         With this method the actual properties are compared. 
         */
        public override bool Equals(object otherCall)
        {
            Type thisType = this.GetType();
            Type otherType = otherCall.GetType();

            PropertyInfo[] thisProperties = thisType.GetProperties();
            PropertyInfo[] otherProperties = otherType.GetProperties();
                       
            for (int i = 0; i < thisProperties.Length; i++)
            {
                //You must use dynamic or call ToString() method!!!!
                //Otherwise, the "Equals" method of the "object" type is invoked and
                //not the property`s actual type "Equals".
                object thisPropertyValue = thisProperties[i].GetValue(this);
                object otherPropertyValue = otherProperties[i].GetValue(otherCall);
                if (thisPropertyValue.ToString() != otherPropertyValue.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Type thisType = this.GetType();
            // You must specify the Instance and Public flags to get the public
            //instance properties.
            //Note: if take the static IPhone4S you get stackoverflow exception!!!
            PropertyInfo[] properties =
                thisType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            StringBuilder phoneInfo = AppendCallPropertiesValues(properties);

            return phoneInfo.ToString();
        }

        private StringBuilder AppendCallPropertiesValues(PropertyInfo[] properties)
        {
            StringBuilder phoneInfo = new StringBuilder();

            phoneInfo.AppendLine("/-----Call Info-----/\n");
            foreach (var property in properties)
            {
                object propertyValue;
                if (property.Name == "Duration")
                {
                    propertyValue = property.GetValue(this) ?? "null";
                    phoneInfo.AppendLine(property.Name + ": " + propertyValue + " s");
                }
                else
                {
                    propertyValue = property.GetValue(this) ?? "null";
                    phoneInfo.AppendLine(property.Name + ": " + propertyValue);
                }
            }
            phoneInfo.AppendLine("/-------------------/");

            return phoneInfo;
        }

    }

}
