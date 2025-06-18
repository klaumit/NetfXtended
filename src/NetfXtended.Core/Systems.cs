using System.Diagnostics;
using System.IO;

namespace NetfXtended.Core
{
    public static class Systems
    {
        public static Process Open(string file, string folder = null)
        {
            var info = new ProcessStartInfo
            {
                FileName = file,
                UseShellExecute = true
            };
            if (!Strings.IsNullOrWhiteSpace(folder))
                info.WorkingDirectory = folder;
            var proc = Process.Start(info);
            return proc!;
        }

        public static string GetTmpFile(string ending)
        {
            var tmpName = Path.GetTempFileName();
            tmpName = tmpName.Replace(".tmp", ending);
            return tmpName;
        }
    }
}