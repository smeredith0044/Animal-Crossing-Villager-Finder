using System;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace VillagerSearch
{
    // Native/JsonFileUtils.cs
    public static class JsonFileUtils
    {
        public static void SimpleWrite(string json, string fileName)
        {
            Console.WriteLine(File.Exists(fileName));
            File.WriteAllText(fileName, json);
            var data = (JObject)JsonConvert.DeserializeObject(json);
            var firstVillagerRecord = data.SelectToken(
               "ant00").Value<string>();
            Console.WriteLine(firstVillagerRecord);

        }
    }
}

