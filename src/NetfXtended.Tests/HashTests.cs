using System.Collections.Generic;
using NetfXtended.Core;
using NUnit.Framework;

#pragma warning disable NUnit2005

namespace NetfXtended.Tests
{
    public class HashTests
    {
        [Test]
        public void Check()
        {
            const string file = "hashes.txt";

            var inputs = new List<string> { "'Hello','World!'" };
            Files.WriteLines(file, inputs);

            var hash = Hashes.Hash(file);
            Assert.AreEqual("0D43B3EA6E2416D38A0491447887084E" +
                            "7ED9B8D8D8540AEBB68A9CF6D80B010B", hash);
        }
    }
}