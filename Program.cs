// See https://aka.ms/new-console-template for more information
using System;
// using System.Collections.Generic; 
Console.Clear();
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

// foreach (var plant in plants){
//     Console.WriteLine($"{plant.Species}");
// }

// Main menu
string choice = null;
while (choice != "0")
{
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
            Console.WriteLine("Are you sure you want to end the program? (y/n)");
            string? response = Console.ReadLine().Trim().ToLower();

            // Console.ReadLine()
            if (response == "y")
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
            PostPlant();
        }
        else if (choice == "3")
        {
            AdaptPlant();
        }
        else if (choice == "4")
        {
            // DelistPlant();
            throw new NotImplementedException();
        }
        else
        {
            Console.WriteLine(@$"{choice} Is not a valid option. Please enter a valid option from the list below.");
            Console.WriteLine("Press any key to go back to select an option...");
            Console.ReadKey();
            choice = null;
            Console.Clear();
        }
}

void ListPlants()
{
        Console.WriteLine("Plants:");

        for (int i = 0; i < plants.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} is available for {plants[i].AskingPrice} dollars.");
        }
}

void PostPlant()
{
    Console.WriteLine("To post a plant, please enter the plant species first: ");
    string species = Console.ReadLine();

    Console.WriteLine("Enter the plant's light needs (1 for shade, 5 for full sun): ");
    string lightNeedsInput = Console.ReadLine();
    int lightNeeds = int.Parse(lightNeedsInput);

    Console.WriteLine("Enter the asking price: ");
    string askingPriceInput = Console.ReadLine();
    decimal askingPrice = decimal.Parse(askingPriceInput);

    Console.WriteLine("Enter the city: ");
    string city = Console.ReadLine();

    Console.WriteLine("Enter the zip: ");
    string zip = Console.ReadLine();
    // .. etc
    plants.Add(new Plant() { Species = species, LightNeeds = lightNeeds, AskingPrice = askingPrice, City = city, ZIP = zip, Sold = false });
    Console.WriteLine($"Successfully added {species} to the plant list!");
}

void AdaptPlant()
{
    Console.WriteLine("To adapt a plant, please enter the number from the following available plants: ");

    List<int> availableIndices = new List<int>();

    for (int i = 0; i < plants.Count; i++)
    {
        if(!plants[i].Sold)
        {
            Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} is available for {plants[i].AskingPrice} dollars.");
            availableIndices.Add(i);
        }
    }

    if (availableIndices.Count == 0)
    {
        Console.WriteLine("There are no plants available for adoption atm.");
        return;
    }

    Console.WriteLine("Enter the number of the plant you want to adopt: ");
    string input = Console.ReadLine();

    int userChoice;
    bool isValidChoice = int.TryParse(input, out userChoice) && userChoice > 0 && userChoice <= availableIndices.Count;
    if(isValidChoice)
    {
        int actualIndex = availableIndices[userChoice - 1];
        plants[actualIndex].Sold = true;
        Console.WriteLine($"You have successfully adapted {plants[actualIndex].Species}!");
    }
    // string adapted = Console.ReadLine();
    // int adapt = int.Parse(adapted);
    // plants.Remove(RemoveAt Plant(adapt) );
}


void availablePlants()
{
    Console.WriteLine("Here are available plants for adaption: ");
    bool hasAvailablePlants = false;
    for (int i = 0; i < plants.Count; i++)
    {
        if(!plants[i].Sold)
        {
          Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} is available for {plants[i].AskingPrice} dollars.");
          hasAvailablePlants = true;
        }
    }

    if (!hasAvailablePlants)
    {
        Console.WriteLine("There are no plants available for adaption atm.");
        // break;
    }
}