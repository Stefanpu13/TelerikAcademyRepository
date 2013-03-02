using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MobilePhone.Functions
{
    public class Display
    {
        private Size? displaySize;
        private int? numberOfColors;
        

        public Display(int? width, int? height, int? numberOfcolors)
        {
            //Doesn`t matter witch of the dimensions is wrong. In bonth cases the default 
            // Display size will be given
            try
            {
                DisplaySize = new Size(width, height);
            }
            catch (ArgumentException ae)
            {
                DisplaySize = Display.DefaultSize;
                Console.WriteLine(ae.Message);
                Console.WriteLine("Display size set to defalt.\n\n");
                Console.WriteLine("Default display size:");
                Console.WriteLine(DefaultSize);
            }
            
            //So I Can continue initialization if first try catches exception
            try
            {                
                NumberOfColors = numberOfcolors;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Console.WriteLine("Number of colors set to 0.\n\n");
            }
            
        }

        public Display(int? width, int? height) : this( width,  height, null) { }

        public Display() : this(null, null) { }

        //Nullable structs What is the result using nullable struct
              

        //In case a defective size( a size with negative dimensions) is created
        //The size will be initialised to this default value 
        private static Size DefaultSize
        {
            get
            {
                return new Size(15, 15);
            }
         
        }

        public Size? DisplaySize
        {
            get
            {
                return this.displaySize;
            }
            set
            {
                this.displaySize = value;
            }
        }

        public int? NumberOfColors
        {
            get
            {                
                return this.numberOfColors;
            }
            set
            {
                //TODO:5. Do checks for all other properties. 
                if (value < 2)
                {
                    NumberOfColors = 2;
                    throw new ArgumentException("Less than 2 of colors entered");
                }
                else
                {
                    this.numberOfColors = value;
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

    public struct Size
    {
        //Select all properties and press Ctrl R,E
        //Properties are generated below the constructors.
        private double? width;
        private double? height;


        public Size(double? width, double? height)
            : this()
        {
            Width = width;
            Height = height;
        }      

        public Size(double? width) : this(width, null) { }

        //Compilation error: You can`t define default constructor for struct
        //TODO: Find info about default constructors in structs. Why are they not allowed?
        //public Size() : this(null) { }

        //public double? Width { get; set; }

        //public double? Height { get; set; }

        //public double? Depth { get; set; }

        public double? Width
        {
            get
            {
                return this.width;
            }
            set
            {
                //TODO:5. Do checks for all other properties. 
                if (value <= 0)
                {
                    //this.width = 0;
                    throw new ArgumentException("Negative or zero width entered");
                    
                }
                else
                {
                    this.width = value;
                }

            }
        }

        public double? Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    //this.height = null;
                    throw new ArgumentException( "Negative or zero height entered");
                }
                else
                {
                    this.height = value;
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
                phoneInfo.AppendLine("\t\t" + property.Name + ": " + propertyValue);
            }

            return phoneInfo.ToString();
        }
    }
}
