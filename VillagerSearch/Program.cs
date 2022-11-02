using System;
using VillagerSearch;
namespace HttpClientStatus;

class Program
{

    // Main Method
    static async Task Main(String[] args)
    {

        // Type your username and press enter
       // Console.WriteLine("Enter villager name:");

        // Create a string variable and get user input from the keyboard and store it in the variable
       // string villagerName = Console.ReadLine();

        // Print the value of the variable (userName), which will display the input value
       // Console.WriteLine("villager is: " + villagerName);

        using var client = new HttpClient();

        var result = await client.GetAsync("https://acnhapi.com/v1/villagers/");
        Console.WriteLine(result.StatusCode);
        string responseBody = await result.Content.ReadAsStringAsync();
        JsonFileUtils.SimpleWrite(responseBody, "/Users/sydney/Sydney_final_project/VillagerSearch/VillagerSearch/VillagerData.json");
    }
}

