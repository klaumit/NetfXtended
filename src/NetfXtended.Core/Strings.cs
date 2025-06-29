using System.Collections.Generic;
using System.Linq;

namespace NetfXtended.Core
{
    public static class Strings
    {
        public static bool IsNullOrWhiteSpace(string text)
        {
#if NETFRAMEWORK
            return TrimOrNull(text) is null;
#else
            return string.IsNullOrWhiteSpace(text);
#endif
        }

        public static string Join<T>(string separator, IEnumerable<T> values, ToStrFunc<T> toStr = null)
        {
            var print = toStr ?? Funcs.Print<T>();
            var array = values.Select(v => print(v)).ToArray();
            return string.Join(separator, array);
        }

        public static string TrimOrNull(string text)
        {
            if (text == null) return null;
            text = text.Trim();
            return text.Length == 0 ? null : text;
        }
    }
}