using NetfXtended.Core;
using NUnit.Framework;

#pragma warning disable NUnit2005

namespace NetfXtended.Tests
{
    public class StringTests
    {
        [Test]
        public void CheckSpace()
        {
            Assert.IsTrue(Strings.IsNullOrWhiteSpace(null));
            Assert.IsTrue(Strings.IsNullOrWhiteSpace(string.Empty));
            Assert.IsTrue(Strings.IsNullOrWhiteSpace("    "));
            Assert.IsFalse(Strings.IsNullOrWhiteSpace("  h   "));
        }

        [Test]
        public void CheckMayNull()
        {
            Assert.AreEqual(null, Strings.TrimOrNull(null));
            Assert.AreEqual(null, Strings.TrimOrNull(string.Empty));
            Assert.AreEqual(null, Strings.TrimOrNull("    "));
            Assert.AreEqual("h", Strings.TrimOrNull("  h   "));
        }
    }
}