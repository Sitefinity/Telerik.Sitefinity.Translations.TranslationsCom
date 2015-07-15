using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// Extension methods 
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// A shortcut for <see cref="M:System.String.IsNullOrEmpty(System.String)"/>
        /// </summary>
        /// <param name="value">String to test</param>
        /// <returns>True if <paramref name="value"/> is <c>null</c> or its <c>Length</c> is 0.</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}