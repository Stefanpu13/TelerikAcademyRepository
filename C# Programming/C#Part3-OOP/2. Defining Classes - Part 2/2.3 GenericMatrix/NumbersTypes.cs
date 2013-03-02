using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;



namespace GenericMatrix
{
    class NumbersTypes
    {
        // A collection of numeric types, used to give constrains to casting with dynamic and
        // avoid arithmetic actions on non-number types.
        // A drawback is the fact that if a new number type must be added, the collection
        // must be appended.
        private static readonly List<Type> numberTypes = new List<Type>() {  typeof(byte), typeof(sbyte),
        typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong),
        typeof(float), typeof(Double), typeof(BigInteger), typeof(Complex)};

        public static List<Type> Types
        {
            get
            {
                return numberTypes;
            }
        }

        public static bool IsNumberType(Type item)
        {
            // The built-in number types(int, double e.t.c.) are part of the "mscorlib" assembly.
            // 1. In that case the "GetType" method can be called that way: Type.GetType(item.Name);
            // 2. In case the number is not part of "mscorlib" assembly(as are "BigInteger" and "Complex"),
            // its fully qualified assembly name has to be taken. 
            // In both cases the "AssemblyQualifiedName" property will work fine
            // (considering that we know the types in the "Main" method(at compile time?))
            // See: http://msdn.microsoft.com/en-us/library/w3f99sx1.aspx for "Type.GetType"
            // See: http://msdn.microsoft.com/en-us/library/system.type.assemblyqualifiedname.aspx 
            // for "Type.AssemblyQualifiedName" property.

            if (item!=null)
            {
                string assemblyName = item.AssemblyQualifiedName;

                Type itemType = Type.GetType(assemblyName);
                return numberTypes.Contains(itemType);
            }
            else
            {
                throw new NotImplementedException();
            }

            
        }
    }

}
