﻿using System;
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
            }
            catch (SystemException e)
            {
                //Catch errors and write to error.txt file in the project path
                string fileName = "error.txt";
                string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                Console.WriteLine("oops there were some errors please see: " + destPath);
                Console.WriteLine(destPath);
                File.WriteAllText(destPath, e.ToString());
                Environment.Exit(0);
            }
        }

        // Type a Villager name and press enter
        Console.WriteLine("Enter villager name:");

        // Create a string variable and get user input from the keyboard and store it in the variable
        string villagerName = Console.ReadLine();

        // Print the value of the variable (villagerName), which will display the input value
        Console.WriteLine("villager is: " + villagerName);

            Boolean matchFound = false;
            foreach (Villager villager in villagerList) {
                foreach (KeyValuePair<string, string> name in villager.name) {

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
}

