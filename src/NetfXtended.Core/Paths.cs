using System;
using System.IO;
using System.Linq;

namespace NetfXtended.Core
{
    public static class Paths
    {
        public static string GetRelativePath(string relativeTo, string path)
        {
#if NETFRAMEWORK || NETSTANDARD2_0
            var fromUri = new Uri(AppendDirectorySeparatorChar(relativeTo));
            var toUri = new Uri(path);
            if (fromUri.Scheme != toUri.Scheme)
            {
                return path;
            }
            var relativeUri = fromUri.MakeRelativeUri(toUri);
            var relativePath = Uri.UnescapeDataString(relativeUri.ToString());
            if (toUri.Scheme.Equals("file", StringComparison.OrdinalIgnoreCase))
            {
                relativePath = relativePath.Replace('/', Path.DirectorySeparatorChar);
            }
            return relativePath;
#else
            return Path.GetRelativePath(relativeTo, path);
#endif
        }

        private static string AppendDirectorySeparatorChar(string path)
        {
            if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                return path + Path.DirectorySeparatorChar;
            }
            return path;
        }

        public static string Combine(string start, params string[] args)
        {
#if NETFRAMEWORK
            var res = start;
            foreach (var arg in args)
                res = Path.Combine(res, arg);
            return res;
#else
            var opt = new[] { start }.Concat(args).ToArray();
            return Path.Combine(opt);
#endif
        }

        public static string GetProjectPath(Type type)
        {
            var ass = type.Assembly;
            var dll = Path.GetFullPath(ass.Location);
            var root = Path.GetDirectoryName(dll)!;
            var s = Path.DirectorySeparatorChar;
            var tmp = $"{s}bin{s}x86{s}";
            if (root.Contains(tmp))
            {
                var root1 = root.Split([tmp], 2, StringSplitOptions.None);
                root = root1.First();
            }
            tmp = $"{s}bin{s}Debug{s}";
            if (root.Contains(tmp))
            {
                var root2 = root.Split([tmp], 2, StringSplitOptions.None);
                root = root2.First();
            }
            return root;
        }

        public static string[] FindFiles(string root, string term = "*.*")
        {
            const SearchOption o = SearchOption.AllDirectories;
            var files = Directory.GetFiles(root, term, o);
            return files;
        }

        public static string CreateDir(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path!);
            return path;
        }
    }
}