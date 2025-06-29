using NetfXtended.Core;
using NUnit.Framework;

#pragma warning disable NUnit2005

namespace NetfXtended.Tests
{
    public class ByteTests
    {
        [Test]
        public void Check()
        {
            byte[] bytes = [34, 21, 23, 46, 93, 32, 11, 127];
            var hex = Bytes.ToHexString(bytes);
            Assert.AreEqual("2215172E5D200B7F", hex);
        }
    }
}