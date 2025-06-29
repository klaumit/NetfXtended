using NetfXtended.Core;
using NUnit.Framework;

#pragma warning disable NUnit2005

namespace NetfXtended.Tests
{
    public class PathTests
    {
        [Test]
        public void CheckProject()
        {
            var path = Paths.GetProjectPath(typeof(Resources));
            Assert.IsTrue(path.Contains(@"\bin\"));
        }
    }
}