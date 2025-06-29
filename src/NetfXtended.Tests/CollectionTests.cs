using System.Collections.Generic;
using NetfXtended.Core;
using NUnit.Framework;

#pragma warning disable NUnit2005

namespace NetfXtended.Tests
{
    public class CollectionTests
    {
        [Test]
        public void Check()
        {
            var list = new List<int> { 4 };
            Collections.AddRange(list, [6, 3, 5]);
            var text = Strings.Join("|", list);
            Assert.AreEqual("4|6|3|5", text);
        }
    }
}