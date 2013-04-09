using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RangeExceptionClass
{
    [Serializable]
    class InvalidRangeException<T> : Exception where T : IComparable, IConvertible
    {
        public InvalidRangeException():base() { }

        public InvalidRangeException(string message) : base(message) { }

        public InvalidRangeException(string message, System.Exception inner) :
            base(message, inner) { }

        public InvalidRangeException(SerializationInfo info,StreamingContext context) : base() { }

        public InvalidRangeException(string message, Range<T> range) :base(message)
        {            
            this.ValidRange = range;
        }

        internal Range<T> ValidRange { get; set; }
    }
}
