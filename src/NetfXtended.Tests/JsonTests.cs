using System;
using System.Collections.Generic;
using NetfXtended.Core;
using NUnit.Framework;

#pragma warning disable NUnit2005

namespace NetfXtended.Tests
{
    public class JsonTests
    {
        public class OneObj
        {
            public OneObj(int idx, string text, DateTime time)
            {
                Idx = idx;
                Text = text;
                Time = time;
            }

            public int Idx { get; set; }
            public string Text { get; set; }
            public DateTime Time { get; set; }
        }

        [Test]
        public void Check()
        {
            var inputs = new List<OneObj>();
            for (var i = 0; i < 10; i++)
                inputs.Add(new OneObj(i, $"{i:X}", new DateTime(2021, 3, 2, i * 2, i * 3, i * 4)));

            const string tmp = "lines.json";
            using (var writer = new JsonLinesWriter<OneObj>(tmp))
                foreach (var item in inputs)
                    writer.WriteLine(item);

            var outputs = new List<OneObj>();
            using (var reader = new JsonLinesReader<OneObj>(tmp))
                while (reader.ReadLine() is { } line)
                    outputs.Add(line);

            var inputTmp = Jsons.WritePlain(inputs, format: false);
            var outputTmp = Jsons.WritePlain(outputs, format: false);
            Assert.AreEqual(inputTmp, outputTmp);
        }
    }
}