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
            Assert.IsTrue(path.Contains(@"\src\"), path);
        }

        [Test]
        public void CheckCombine()
        {
            var path = Paths.Combine("a", "b", "c", "d");
            Assert.AreEqual(@"a\b\c\d", path);
        }

        [Test]
        public void CheckCreateDir()
        {
            const string tmp = "a";
            Assert.AreEqual(tmp, Paths.CreateDir(tmp));
        }

        [Test]
        public void CheckFindFiles()
        {
            var root = Paths.GetProjectPath(typeof(Resources));
            var list = Paths.FindFiles(root);
            Assert.IsTrue(list.Length >= 20, $"{list.Length}");
        }

        [Test]
        public void CheckRelativePath()
        {
            var root = Paths.GetProjectPath(typeof(Resources));
            var list = Paths.FindFiles(root);
            var first = list[0];
            var rel = Paths.GetRelativePath(root, first);
            Assert.IsTrue(rel.Length >= 8+3, rel);
        }
    }
}