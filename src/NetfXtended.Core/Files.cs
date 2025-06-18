using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetfXtended.Core
{
    public static class Files
    {
        public static IEnumerable<string> ReadLines(string file, Encoding enc)
        {
#if NET20 || NET35
            return File.ReadAllLines(file, enc);
#else
            return File.ReadLines(file, enc);
#endif
        }
    }
}