using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace VillagerSearch
{
    public class Villager
    {
        public string id { get; set; }
        public IDictionary<string, string> name { get; set; }
        public string personality { get; set; }
        public string birthday { get; set; }
        public string species { get; set; }
        public string gender { get; set; }
        public string subtype { get; set; }
        public string hobby { get; set; }
        //public string catch-phrase { get; set; }
        public string icon_uri { get; set; }
        public string image_uri { get; set; }
        //public string bubble-color { get; set; }
        //public string text-color { get; set; }
        public string saying { get; set; }
        //public IDictionary<string, string> catch-translations { get; set; }

        // extra fields
        [Newtonsoft.Json.JsonExtensionData]
        private IDictionary<string, JToken> _extraStuff;
        public Villager()
        {
        }

        override
        public string ToString()
        {
            var jsonString = JsonConvert.SerializeObject(
           this, Formatting.Indented,
           new JsonConverter[] { new StringEnumConverter() });
            return jsonString;
        }
    }
}

