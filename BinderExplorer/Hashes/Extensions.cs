using System.Collections.Generic;

namespace HashLib
{
    public static class Extensions
    {
        public static List<string> ToStringList<T>(this IEnumerable<T> values)
        {
            var strs = new List<string>();
            foreach (var value in values)
                strs.Add($"{value}");
            return strs;
        }
    }
}
