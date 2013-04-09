using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeExceptionClass
{
    class ExceptionTestingApp<T> where T : IComparable, IConvertible
    {
        public ExceptionTestingApp(T minValue, T maxValue)
        {
            this.RangeException = new InvalidRangeException<T>("Value out of range", new Range<T>(minValue, maxValue));
            
        }

        InvalidRangeException<T> RangeException { get; set; }

        List<T> Data { get; set; }

        internal T EnterValue<T>() 
        {
            Console.WriteLine("Enter values of type {0}: ", typeof(T).FullName);

            T value = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

            if (IsOutsideRange(this.RangeException.ValidRange, value))
            {
                throw this.RangeException;
            }

            else
            {
                return value;
            }
        }

        private bool IsOutsideRange(Range<T> range, object value)
        {
            return ((T) value).CompareTo(range.MinValue)<0 ||
                ((T)value).CompareTo(range.MaxValue) > 0;
        }

      

    }
}
