using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeExceptionClass
{
    struct Range<T> where T : IComparable, IConvertible
    {
       internal Range(T minValue, T maxValue)
            : this()
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

       internal T MinValue { get; set; }
       internal T MaxValue { get; set; }

       public override string ToString()
       {
           return string.Format("[{0}, {1}]", this.MinValue, this.MaxValue);
       }
    }
}
