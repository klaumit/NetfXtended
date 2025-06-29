using System.Text;
using NetfXtended.Core;
using NUnit.Framework;

// ReSharper disable RedundantArgumentDefaultValue

#pragma warning disable NUnit2005

namespace NetfXtended.Tests
{
    public class StreamTests
    {
        [Test]
        public void CheckDeflate()
        {
            const string input = "Hello world, what is going on?!";
            var zip = Compressions.Compress(Encoding.UTF8.GetBytes(input), CompressionKind.Deflate);
            var output = Encoding.UTF8.GetString(Compressions.Decompress(zip, CompressionKind.Deflate));
            Assert.AreEqual(input, output);
        }

        [Test]
        public void CheckZip()
        {
            const string input = "Hello world, what is going on?!";
            var zip = Compressions.Compress(Encoding.UTF8.GetBytes(input), CompressionKind.GZip);
            var output = Encoding.UTF8.GetString(Compressions.Decompress(zip, CompressionKind.GZip));
            Assert.AreEqual(input, output);
        }
    }
}