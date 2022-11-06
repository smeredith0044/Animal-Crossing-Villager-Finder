using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VillagerSearch;
namespace HttpClientStatus;

class Program
{

    // Main Method
    static async Task Main(String[] args)
    {

        // Type a Villager name and press enter
        Console.WriteLine("Enter villager name:");

        // Create a string variable and get user input from the keyboard and store it in the variable
        string villagerName = Console.ReadLine();

        // Print the value of the variable (villagerName), which will display the input value
        Console.WriteLine("villager is: " + villagerName);

        using var client = new HttpClient();

        var result = await client.GetAsync("https://acnhapi.com/v1/villagers/");
        Console.WriteLine(result.StatusCode);
        string responseBody = await result.Content.ReadAsStringAsync();
        dynamic objects = JsonConvert.DeserializeObject(@responseBody); // parse as array  
        List<Villager> villagerList = new List<Villager>();
        foreach (var root in objects)
        {
            try
            {
                string value = Convert.ToString(root.Value);
                Villager villager = JsonConvert.DeserializeObject<Villager>(value);
                villagerList.Add(villager);
            } catch (SystemException e)
            {
                Console.WriteLine(e);
            }
        }
            foreach (Villager villager in villagerList) {
                foreach (KeyValuePair<string, string> name in villager.name) {

                if (villagerName != null)
                {
                    if (name.Value.ToLower().Equals(villagerName.ToLower()))
                    {
                        Console.WriteLine("theres a match!");
                        Console.WriteLine(villager.ToString());

                        break;
                    }
                }
                }
            }
        }
}

