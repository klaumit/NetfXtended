using System;
using System.Text;

namespace NetfXtended.Core
{
    public static class Bytes
    {
        public static string ToHexString(byte[] bytes)
        {
#if NETFRAMEWORK || NETSTANDARD2_0
            var sb = new StringBuilder();
            foreach (var b in bytes)
                sb.Append(b.ToString("X2"));
            return sb.ToString();
#else
            return Convert.ToHexString(bytes);
#endif
        }
    }
}