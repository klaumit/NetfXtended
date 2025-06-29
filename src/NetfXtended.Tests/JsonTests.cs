using System;
using System.Collections.Generic;
using NetfXtended.Core;
using NUnit.Framework;

#pragma warning disable NUnit2005

namespace NetfXtended.Tests
{
    public class JsonTests
    {
        private static List<OneObj> CreateList()
        {
            var inputs = new List<OneObj>();
            for (var i = 0; i < 10; i++)
                inputs.Add(new OneObj(i, $"{i:X}", new DateTime(2021, 3, 2, i * 2, i * 3, i * 4)));
            return inputs;
        }

        [Test]
        public void CheckLines()
        {
            var inputs = CreateList();

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

        [Test]
        public void CheckFiles()
        {
            var inputs = CreateList();

            const string file = "files.json";
            Jsons.WriteJson(inputs, file, format: true);

            var outputs = Jsons.ReadJson<List<OneObj>>(file);

            var inputsT = Strings.Join("|", inputs);
            var outputsT = Strings.Join("|", outputs);
            Assert.AreEqual(inputsT, outputsT);
        }
    }
}