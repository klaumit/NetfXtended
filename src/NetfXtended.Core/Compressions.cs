using System;
using System.IO;
using System.IO.Compression;

namespace NetfXtended.Core
{
    public static class Compressions
    {
        public static Stream GetStream(CompressionKind kind, CompressionMode mode, Stream stream)
        {
            switch (kind)
            {
                case CompressionKind.Deflate: return new DeflateStream(stream, mode, leaveOpen: true);
                case CompressionKind.GZip: return new GZipStream(stream, mode, leaveOpen: true);
                default: throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
            }
        }

        public static byte[] Compress(byte[] source, CompressionKind kind = default)
        {
            using var input = new MemoryStream(source);
            using var output = new MemoryStream();
            Compress(input, output, kind);
            return output.ToArray();
        }

        public static void Compress(Stream source, Stream target, CompressionKind kind = default)
        {
            using var zip = GetStream(kind, CompressionMode.Compress, target);
            source.CopyAndFlush(zip);
        }

        public static byte[] Decompress(byte[] source, CompressionKind kind = default)
        {
            using var input = new MemoryStream(source);
            using var output = new MemoryStream();
            Decompress(input, output, kind);
            return output.ToArray();
        }

        public static void Decompress(Stream source, Stream target, CompressionKind kind = default)
        {
            using var zip = GetStream(kind, CompressionMode.Decompress, source);
            zip.CopyAndFlush(target);
        }
    }
}