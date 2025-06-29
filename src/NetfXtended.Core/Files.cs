using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NetfXtended.Core
{
    public static class Files
    {
        public static IEnumerable<string> ReadLines(string file, Encoding enc = null)
        {
            var encT = enc ?? Encoding.UTF8;
#if NET20 || NET35
            return File.ReadAllLines(file, encT);
#else
            return File.ReadLines(file, encT);
#endif
        }

        public static void WriteLines(string file, IEnumerable<string> lines, Encoding enc = null)
        {
            var encT = enc ?? Encoding.UTF8;
#if NET20 || NET35
            var array = lines.ToArray();
            File.WriteAllLines(file, array, encT);
#else
            File.WriteAllLines(file, lines, encT);
#endif
        }
    }
}