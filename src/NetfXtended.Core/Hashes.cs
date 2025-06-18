using System.IO;
using System.Security.Cryptography;

namespace NetfXtended.Core
{
    public static class Hashes
    {
        public static string Hash(string file)
        {
            using var stream = File.OpenRead(file);
            return Hash(stream);
        }

        public static string Hash(Stream stream)
        {
#if NETFRAMEWORK
            using var algo = SHA256.Create();
            var hash = algo.ComputeHash(stream);
#else
            var hash = SHA256.HashData(stream);
#endif
            var hashTxt = Bytes.ToHexString(hash);
            return hashTxt;
        }
    }
}