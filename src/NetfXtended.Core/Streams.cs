using System.IO;

namespace NetfXtended.Core
{
    public static class Streams
    {
        public static void CopyAndFlush(this Stream source, Stream dest)
        {
#if NET20 || NET35
            void CopyTo(Stream input, Stream output, int buffSize = 81920)
            {
                var buffer = new byte[buffSize];
                int count;
                while ((count = input.Read(buffer, 0, buffer.Length)) != 0)
                    output.Write(buffer, 0, count);
            }

            CopyTo(source, dest);
#else
            source.CopyTo(dest);
#endif
            dest.Flush();
        }
    }
}