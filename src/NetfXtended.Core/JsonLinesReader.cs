using System.IO;
using System;
using System.Text;

namespace NetfXtended.Core
{
    public sealed class JsonLinesReader<T> : IDisposable
    {
        private readonly StreamReader _reader;

        public JsonLinesReader(string file) : this(File.OpenRead(file))
        {
        }

        public JsonLinesReader(Stream stream)
        {
            _reader = new StreamReader(stream, Encoding.UTF8);
        }

        private string ReadNext()
        {
            return _reader.ReadLine()?.Trim(',', ' ');
        }

        public T ReadLine()
        {
            var line = ReadNext();
            if (line == null)
                return default;
            if (line.Equals("["))
                line = ReadNext();
            if (line.Equals("]"))
                return default;
            var item = Jsons.ReadPlain<T>(line);
            return item;
        }

        public void Dispose()
        {
            _reader.Dispose();
        }
    }
}