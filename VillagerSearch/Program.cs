using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VillagerSearch;
using static System.Net.Mime.MediaTypeNames;

namespace HttpClientStatus;

class Program
{

    // Main Method
    static async Task Main(String[] args)
    {
        bool backTop = true;

        while (backTop)
        {
            List<Villager> villagerList = new List<Villager>();
            try
            {


                using var client = new HttpClient();

                var result = await client.GetAsync("https://acnhapi.com/v1/villagers/");
                Console.WriteLine(result.StatusCode);
                villagerList = await GetVillagerList(result);
            }
            catch (Exception e)
            {
                //Catch errors and write to error.txt file in the debug folder 
                string fileName = "error.txt";
                string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                Console.WriteLine("oops there were some errors please see: " + destPath);
                Console.WriteLine(destPath);
                File.WriteAllText(destPath, e.ToString());
                Villager emergencyVillager = new Villager();
                IDictionary<string, string> name = new Dictionary<string, string>();
                name.Add("name-USen", "raymond");
                emergencyVillager.name = name;
                villagerList.Add(emergencyVillager);

            }
            // Type a Villager name and press enter
            Console.WriteLine("Enter villager name:");

            // Create a string variable and get user input from the keyboard and store it in the variable
            string villagerName = Console.ReadLine();

            // Print the value of the variable (villagerName), which will display the input value
            Console.WriteLine("villager is: " + villagerName);

            Boolean matchFound = false;
            foreach (Villager villager in villagerList)
            {
                foreach (KeyValuePair<string, string> name in villager.name)
                {

                    if (villagerName != null)
                    {
                        if (name.Value.ToLower().Equals(villagerName.ToLower()))
                        {
                            matchFound = true;
                            Console.WriteLine("theres a match!");
                            villager.print(false);
                            break;

                        }

                    }
                }

            }
            if (!matchFound)
            {
                Console.WriteLine("No match found, please try again!");
            }

        }
        backTop = false;

    }

    private static async Task<List<Villager>> GetVillagerList(HttpResponseMessage result)
    {
        string responseBody = await result.Content.ReadAsStringAsync();
        dynamic objects = JsonConvert.DeserializeObject(@responseBody); // parse as array  
        List<Villager> villagerList = new List<Villager>();

        foreach (var root in objects)
        {
            string value = Convert.ToString(root.Value);
            Villager villager = JsonConvert.DeserializeObject<Villager>(value);
            villagerList.Add(villager);

        }
        return villagerList;

    }
}

