using System;
using System.Linq;


namespace StudentsInfo
{
    class ReversedStringComparer:StringComparer
    {
        public override int Compare(string first, string second)
        {
            return second.CompareTo(first);
        }

        public override bool Equals(string first, string second)
        {
            return first.Equals(second);
        }

        public override int GetHashCode(string stringObject)
        {
            return stringObject.GetHashCode();
        }
    }
}
