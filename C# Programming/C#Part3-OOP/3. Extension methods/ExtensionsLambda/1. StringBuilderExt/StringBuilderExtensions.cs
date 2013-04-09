using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.StringBuilderExt
{
    static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder text, int index)
        {
            if (index < 0 || index >= text.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            else
            {
                StringBuilder substringText = new StringBuilder();

                for (int i = index; i < text.Length; i++)
                {
                    substringText.Append(text[i]);
                }

                return substringText;
            }
        }
    }
}
