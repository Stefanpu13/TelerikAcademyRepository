namespace Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /* Note:
     * Method "ToValidLatinFileName()" changed to throw ArgumentNullException.
     * For training purposes only.
     */

    public static class StringExtensions
    {        
        /// <summary>
        /// Computes hash code of the given input using Md5 hashing algorithm.
        /// </summary>
        /// <param name="input">The input string whose hexadecimal hash code is computed.</param>
        /// <returns>The hexadecimal representation of the hash code for the given input.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Checks if the given input can be presented as "true" value.
        /// </summary>
        /// <param name="input">A string to be checked. </param>
        /// <returns>True if the input string can be presented as "true" value, false otherwise.</returns>
        /// <remarks> The values that are interpreted as "true" are: "true" , "ok"
        /// "yes", "1", "да". Any different input will be interpreted as "false".
        /// The check is case insensitive.</remarks>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit signed integer equivalent. 
        /// Return indicates whether the conversion was successfull or not.
        /// </summary>
        /// <param name="input">The string to be converted. </param>
        /// <returns>True if conversion is successfull, false otherwise.</returns>
        /// <remarks><see cref="Int16.TryParse"/> is internally used to convert the input string.
        /// </remarks>         
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer equivalent. 
        /// Return indicates whether the conversion was successfull or not.        
        /// </summary>
        /// <param name="input">The string to be converted. </param>
        /// <returns>True if conversion is successfull, false otherwise.</returns>
        /// <remarks><see cref="Int32.TryParse"/> is internally used to convert the input string.
        /// </remarks>        
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit signed integer equivalent. 
        /// Return indicates whether the conversion was successfull or not.        
        /// </summary>
        /// <param name="input">The string to be converted. </param>
        /// <returns>True if conversion is successfull, false otherwise.</returns>
        /// <remarks><see cref="Int64.TryParse"/> is internally used to convert the input string.
        /// </remarks>        
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the string representation of a number to its DateTime equivalent. 
        /// Return indicates whether the conversion was successfull or not.        
        /// </summary>
        /// <param name="input">The string to be converted. </param>
        /// <returns>True if conversion is successfull, false otherwise.</returns>
        /// <remarks> <see cref="DateTime.TryParse"/> is internally used to convert the input string.
        /// </remarks>        
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes the first letter of the given string. 
        /// </summary>
        /// <param name="input"> A string whose first letter is capitalized. </param>
        /// <returns> A copy of the given string with capitalized first letter, or null if the input
        /// string is null or empty.</returns>
        /// <remarks><see cref="String.ToUpper"/> method is used to convert the first letter to uppercase.
        /// The current culture casing rules are always used.</remarks>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) +
                input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Gets the content between the first occurences of two specified substrings
        /// in a given examined string. The examined string is a substring
        /// of the input and starts from a given position.
        /// </summary>
        /// <param name="input">The string from which the examined string is taken.</param>
        /// <param name="startString">The string whose end determines the start of the content.</param>
        /// <param name="endString">The string whose beginning determines the end of the content.</param>
        /// <param name="startFrom">The starting index position of the examined string
        /// in the input string. </param>
        /// <returns>A string representing the content between the start string and the end string
        /// or empty string if no match is found.</returns>
        /// <remarks>The "startString" and the "endString" are not included in the content.
        /// The method uses ordinal, case - sensitive string comparison to look for the position of the
        /// strarting and ending strings.</remarks>
        public static string GetStringBetween(
            this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);

            // "startFrom" is set to 0 so it can be used in the current "input" value
            // that is a substring of the original "input" value.
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) +
                                startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Replaces the cyrillic letters in the given input with latin letters. 
        /// </summary>
        /// <param name="input">A string whose cyrillic letters are going to be replaced. </param>
        /// <returns>A string with cyrillic letters replaced for latin letters. </returns>
        /// <remarks> If the latin equivalent of a given capital cyrillic letter consists
        /// of more than one letter, only the first letter is capitalized.</remarks>
        /// <example>
        /// "Ютия"-> "Yutiya"
        /// </example>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                {
                    "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                    "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                };
            var latinRepresentationsOfBulgarianLetters = new[]
                {
                    "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                    "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                    "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(),
                                      latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts the latin letters in a given string to their cyrillic equivalent.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <returns>The converted variant of the string.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                {
                    "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                    "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                {
                    "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                    "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                    "в", "ь", "ъ", "з"
                };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].
                    ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts given string to a valid username.
        /// </summary>
        /// <param name="input">The input string to be validated.</param>
        /// <returns>The string representation of the username.</returns>
        /// <remarks>The method considers only latin letters, digits, "_"(underscore) and "."(dot)
        /// as valid username symbols. All invalid symbols are replaced with <see cref="string.Empty"/>.
        /// Any ciryllic letters are first converted to latin - <see cref="ConvertCyrillicToLatinLetters()"/>
        /// </remarks>
        /// <example>
        /// <code>
        /// class ExamplesClass
        /// {
        ///     static void Main(string[] args)
        ///     {
        ///         var input = "Гоод Examпле??";
        ///         var validatedUsername = input.ToValidUsername();
        ///
        ///         // Prints: "GoodExample"
        ///         Console.WriteLine(validatedUsername);
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts the given string to a valid filename.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>The string representation of the filename. </returns>
        /// <remarks>The method considers only latin letters, digits, "_"(underscore), "-"(hyphen)
        /// and "."(dot) as valid username symbols. All invalid symbols are replaced
        /// with <see cref="string.Empty"/>. Any ciryllic letters are first converted to latin -
        /// <see cref="ConvertCyrillicToLatinLetters()"/>. White spaces will be replaced with hyphens.
        /// </remarks> 
        /// <example>
        /// <code>
        /// private static void PerformValidateUsernameExample()
        /// {
        ///     var input = "Тхиs will =have   some hypенс.";
        ///     var validatedFilename = input.ToValidLatinFileName();
        ///
        ///     // Prints: "This-will-have---some-hypens."
        ///     Console.WriteLine(validatedFilename);
        /// }
        /// </code>
        /// </example>
        public static string ToValidLatinFileName(this string input)
        {
            if (input==null)
            {
                string message = "Null input can not be validated as filename.";
                throw new ArgumentNullException("input", message);
            }

            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Gets the specified number of consecutive characters from a given string, starting 
        /// from the beginning of the string.
        /// </summary>
        /// <param name="input">The string to get the characters from.</param>
        /// <param name="charsCount">The number of characters to take.</param>
        /// <returns>A string of the characters taken.</returns>
        /// <remarks>If the specified characters count is bigger or equal to 
        /// the input string length, then the whole string is returned.</remarks>
        public static string GetFirstCharacters(this string input, int charsCount)
        {

            return input.Substring(0, Math.Min(input.Length, charsCount));
        }
        /// <summary>
        /// Gets the file extension from a given filename.
        /// </summary>
        /// <param name="fileName">The name of the file</param>
        /// <returns>The file extension as a string. </returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }
        
        /// <summary>
        /// Converts the given file extension to the repsective content type.
        /// </summary>
        /// <param name="fileExtension">The file extension as a string. </param>
        /// <returns>The content type as a string.</returns>
        /// <remarks>The method recognizes the following file extensions 
        /// correspondnig to the respective content types :
        /// 
        /// "jpg" - "image/jpeg", "jpeg" - "image/jpeg", "png", "image/x-png",
        /// "docx"- "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        /// "doc", "application/msword","txt" - "text/plain", "rtf" - "application/rtf". 
        /// If the input string is not in any of the described file extensions,
        /// then "application/octet-stream" content type is returned.</remarks>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                {
                    {"jpg", "image/jpeg"},
                    {"jpeg", "image/jpeg"},
                    {"png", "image/x-png"},
                    {
                        "docx",
                        "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                    },
                    {"doc", "application/msword"},
                    {"doc", "application/msword"},
                    {"txt", "text/plain"},
                    {"rtf", "application/rtf"}
                };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts the given string to an array of bytes.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>A byte array representing the input string.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
