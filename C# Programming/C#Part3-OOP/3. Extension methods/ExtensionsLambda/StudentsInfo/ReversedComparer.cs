using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsInfo
{
    class ReversedComparer:Comparer<string>
    {
        public override int Compare(string x, string y)
        {
            return y.CompareTo(x);
        }
    }
}
