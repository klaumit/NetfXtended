using System.Collections.Generic;
using NetfXtended.Core;
using NUnit.Framework;

#pragma warning disable NUnit2005

namespace NetfXtended.Tests
{
    public class FileTests
    {
        [Test]
        public void Check()
        {
            const string file = "files.txt";

            var inputs = new List<string> { "'Hello','World!'" };
            Files.WriteLines(file, inputs);

            var outputs = Files.ReadLines(file);
            Assert.AreEqual(inputs, outputs);
        }
    }
}