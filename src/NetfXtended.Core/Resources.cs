using System.IO;
using System.Linq;

namespace NetfXtended.Core
{
    public static class Resources
    {
        public static Stream FindByManifest<T>(string name)
        {
            var type = typeof(T);
            var ass = type.Assembly;
            var names = ass.GetManifestResourceNames();
            var item = names.FirstOrDefault(n => n.EndsWith($".{name}"));
            var stream = ass.GetManifestResourceStream(item)!;
            return stream;
        }
    }
}