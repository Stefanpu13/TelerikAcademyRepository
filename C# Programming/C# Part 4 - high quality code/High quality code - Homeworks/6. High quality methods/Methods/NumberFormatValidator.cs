using System;
using System.Runtime.CompilerServices;

// You add this file to get access to the internal types and members of the current assembly.
// See "MethodsTests", "ConsoleNumberPrinterTests" for more infromation.
[assembly: InternalsVisibleTo("MethodsTests")]

namespace Methods
{
    // Look for additional information about standard number format strings or
    // see: http://msdn.microsoft.com/en-us/library/dwhawy9k.aspx, section "Description", 
    // subsection "Supported by:".
    internal abstract class NumberFormatValidator
    {
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if any of the provided arguments is null. 
        /// </summary>
        /// <param name="number">The object representing the number examined.</param>
        /// <param name="format">The standard number format specifier.</param>
        internal static void ThrowExceptionIfNull(object number, string format)
        {
            if (number == null)
            {
                throw new ArgumentNullException("number");
            }

            if (format == null)
            {
                throw new ArgumentNullException("format");
            }
        }

        internal abstract void ThrowExceptionIfIsInvalid(string format);

        internal abstract void ThrowExceptionIfCanNotBeFormatted(object number);

        /// <summary>
        /// Checks if the given object can be unboxed to any of the .NET buit-in numeric types. 
        /// </summary>
        /// <param name="number">The object to be checked.</param>
        /// <returns>True if object is a number, false otherwise.</returns>
        protected static bool IsNumber(object number)
        {
            if (number is byte || number is sbyte || number is short || number is ushort ||
                number is int || number is uint || number is long || number is ulong ||
                number is float || number is double)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///  Checks if the object represents a number that can be formatted using the respective
        /// number format. The implementation in the "NumberFormatValidator" class returns true
        /// if the passed object is a .NET built-in numeric type. The reason to do this
        /// is because many of the standard numeric formats are supported by all built-in numeric 
        /// types.
        /// </summary>
        /// <param name="number">The object to be checked.</param>
        /// <returns>True if object is number, fasle otherwise.</returns>
        protected virtual bool CanBeFormatted(object number)
        {
            return IsNumber(number);
        }
    }
}
