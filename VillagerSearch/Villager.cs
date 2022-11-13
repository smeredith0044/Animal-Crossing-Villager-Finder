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
        public string CatchPhrase { get; set; }
        public string icon_uri { get; set; }
        public string image_uri { get; set; }
        public string BubbleColor { get; set; }
        public string TextColor { get; set; }
        public string saying { get; set; }
        public IDictionary<string, string> CatchTranslations { get; set; }

        // extra fields
        [Newtonsoft.Json.JsonExtensionData]
        private IDictionary<string, JToken> _extraStuff;
        public Villager()
        {
        }

        public void print(Boolean getAsJson)
        {
            if (getAsJson)
            {
                printAsJsonString();
            }
            else
            {
                printAsPlainText();
            }
        }

        private void printAsPlainText()
        {
            Console.WriteLine("name: " + this.name["name-USen"]);
            Console.WriteLine("personality: " + this.personality);
            Console.WriteLine("birthday: " + this.birthday);
            Console.WriteLine("species: " + this.species);
            Console.WriteLine("gender: " + this.gender);
            Console.WriteLine("hobby: " + this.hobby);
            Console.WriteLine("CatchPhrase: " + this.CatchPhrase);
            Console.WriteLine("saying: " + this.saying);
            Console.WriteLine("CatchTranslations: " + this.CatchTranslations["catch-USen"]);
        }

        private void printAsJsonString()
        {
            String json = JsonConvert.SerializeObject(
           this, Formatting.Indented,
           new JsonConverter[] { new StringEnumConverter() });
            Console.WriteLine(json);
        }
    }
}

