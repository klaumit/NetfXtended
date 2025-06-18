using NetfXtended.WinForms;
using NUnit.Framework;

#pragma warning disable NUnit2005

namespace NetfXtended.Tests
{
    public class PathTests
    {
        [Test]
        public void Check()
        {
            using var img = Images.FindByManifest<PathTests>("funny.png");
            Assert.AreEqual(337, img.Width);
            Assert.AreEqual(327, img.Height);
            Assert.AreEqual(95, (int)img.HorizontalResolution);
            Assert.AreEqual(95, (int)img.VerticalResolution);
        }
    }
}