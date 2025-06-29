using NetfXtended.Core;
using NUnit.Framework;

#pragma warning disable NUnit2005

namespace NetfXtended.Tests
{
    public class ValueTests
    {
        [Test]
        public void Check()
        {
            Assert.AreEqual(-9229841, Values.ParseHexS("FF7329EF"));
            Assert.AreEqual(4285737455, Values.ParseHexU("FF7329EF"));
        }
    }
}