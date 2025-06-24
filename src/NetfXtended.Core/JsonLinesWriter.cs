using System.IO;
using System;
using System.Text;

namespace NetfXtended.Core
{
    public sealed class JsonLinesWriter<T> : IDisposable
    {
        private readonly StreamWriter _writer;
        private bool _first;

        public JsonLinesWriter(string file) : this(File.Create(file))
        {
        }

        public JsonLinesWriter(Stream stream)
        {
            _first = true;
            _writer = new StreamWriter(stream, Encoding.UTF8);
            _writer.WriteLine("[");
        }

        public void WriteLine(T item)
        {
            if (_first)
                _first = false;
            else
            {
                _writer.Write(",");
                _writer.WriteLine();
            }
            var line = Jsons.WritePlain(item, format: false);
            _writer.Write(line);
        }

        public void Dispose()
        {
            _writer.WriteLine();
            _writer.WriteLine("]");
            _writer.Flush();
            _writer.Dispose();
        }
    }
}