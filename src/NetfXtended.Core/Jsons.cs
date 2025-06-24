using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NetfXtended.Core
{
    public static class Jsons
    {
        public static string WritePlain(object val, bool format = true)
        {
            var res = JsonConvert.SerializeObject(val, GetConfig(format));
            return res!;
        }

        public static void WriteJson(object val, string file, bool format = true)
        {
            var json = WritePlain(val, format);
            File.WriteAllText(file, json, Encoding.UTF8);
        }

        public static T ReadPlain<T>(string json)
        {
            var res = JsonConvert.DeserializeObject<T>(json, GetConfig());
            return res!;
        }

        public static T ReadJson<T>(string file)
        {
            if (!File.Exists(file)) return Activator.CreateInstance<T>();
            var json = File.ReadAllText(file, Encoding.UTF8);
            var res = ReadPlain<T>(json);
            return res!;
        }

        private static JsonSerializerSettings GetConfig(bool format = true)
        {
            var config = new JsonSerializerSettings
            {
                Formatting = format ? Formatting.Indented : Formatting.None,
                Converters = { new StringEnumConverter() },
                NullValueHandling = NullValueHandling.Ignore
            };
            return config;
        }
    }
}