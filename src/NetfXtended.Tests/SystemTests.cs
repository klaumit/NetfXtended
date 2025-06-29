using System.ComponentModel;
using NetfXtended.Core;
using NUnit.Framework;

#pragma warning disable NUnit2005

namespace NetfXtended.Tests
{
    public class SystemTests
    {
        [Test]
        public void CheckTmpFile()
        {
            var path = Systems.GetTmpFile("json");
            Assert.IsTrue(path.Contains(@"\AppData\Local\Temp\"));
        }

        [Test]
        public void CheckOpen()
        {
            Assert.Throws<Win32Exception>(() => Systems.Open("test.json"));
        }
    }
}