using System.Drawing;
using NetfXtended.Core;

namespace NetfXtended.WinForms
{
    public static class Images
    {
        public static Image FindByManifest<T>(string name)
        {
            var stream = ResourcesX.FindByManifest<T>(name);
            var image = Image.FromStream(stream);
            return image;
        }
    }
}