// See https://aka.ms/new-console-template for more information
using System;
// using System.Collections.Generic; 

string greeting = "Welcome to ExtraVert's Plants shop!";
Console.WriteLine(greeting);

// Declared globally
List<Plant> plants = new List<Plant>()
{
    new Plant() { Species = "Monstera", LightNeeds = 3, AskingPrice = 25.00M, City = "Atlanta", ZIP = "30301", Sold = false },
    new Plant() { Species = "Snake Plant", LightNeeds = 2, AskingPrice = 15.50M, City = "New York", ZIP = "10001", Sold = false },
    new Plant() { Species = "Cactus", LightNeeds = 5, AskingPrice = 12.75M, City = "Phoenix", ZIP = "85001", Sold = true },
    new Plant() { Species = "Fern", LightNeeds = 1, AskingPrice = 18.00M, City = "Seattle", ZIP = "98101", Sold = false },
    new Plant() { Species = "Aloe Vera", LightNeeds = 4, AskingPrice = 20.00M, City = "Miami", ZIP = "33101", Sold = true },
};  

foreach (var plant in plants){
    Console.WriteLine($"{plant.Species}");
}

// Main menu
string choice = null;
while (choice != "0")
{
Console.Clear();
Console.WriteLine(@"
Select an option:
0. Exit
1. View all plants
2. Post a plant for adaption
3. Adapt a plant
4. Delist a plant
");

        choice = Console.ReadLine();
        if (choice == "0")
        {
            Console.WriteLine("Are you sure you want to end the program? (yes/no)");
            string? response = Console.ReadLine().Trim().ToLower();

            // Console.ReadLine()
            if (response == "yes")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Returning to the main menu...");
                choice = null;
            }
        }
        else if (choice == "1")
        {
            ListPlants();
        }
        else if (choice == "2")
        {
            // PostPlant();
            throw new NotImplementedException();
        }
        else if (choice == "3")
        {
            // AdaptPlant();
            throw new NotImplementedException();
        }
        else if (choice == "4")
        {
            // DelistPlant();
            throw new NotImplementedException();
        }
        else
        {
            Console.WriteLine(@$"{choice} Is not a valid option. Please enter a valid option from the list below.");
            choice = null;
        }
}

void ListPlants()
{
        Console.WriteLine("Plants:");

        for (int i = 0; i < plants.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {plants[i].Species}");
        }
}