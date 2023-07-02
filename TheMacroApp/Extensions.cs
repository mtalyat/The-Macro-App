using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMacroApp
{
    /// <summary>
    /// Adds useful extensions to various classes.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Creates a sub-array from this array.
        /// </summary>
        /// <typeparam name="T">The type of array to create a sub array from.</typeparam>
        /// <param name="array">The array to create the sub array from.</param>
        /// <param name="offset">The starting index in the array to create the sub array.</param>
        /// <param name="length">The number of elements to include in the sub array.</param>
        /// <returns>The sub array using the given offset and length, from this array.</returns>
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }

        /// <summary>
        /// Inserts spaces before any uppercase letters in the string.
        /// </summary>
        /// <param name="text">The text to insert spaces into.</param>
        /// <returns>The string with spaces inserted.</returns>
        public static string InsertSpaces(this string text)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in text)
            {
                if(c >= 'A' && c < 'Z')
                {
                    sb.Append(' ');
                }

                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
