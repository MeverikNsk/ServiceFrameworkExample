namespace Vsk.VooDoo.Core.Extensions
{
    using System;

    public static class StringExtensions
    {
        public static string RemoveAsync(this string str)
        {
            if (str.EndsWith("Async", StringComparison.OrdinalIgnoreCase))
            {
                return str.Substring(0, str.Length - 5);
            }

            return str;
        }
    }
}
