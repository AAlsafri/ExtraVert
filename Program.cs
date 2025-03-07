// See https://aka.ms/new-console-template for more information
using System;

Console.Clear();
string greeting = "Welcome to ExtraVert's Plants shop!";
Console.WriteLine(greeting);

// Declared globally
Random randomPlant = new Random();
List<Plant> plants = new List<Plant>()
{
    new Plant() { Species = "Monstera", LightNeeds = 3, AskingPrice = 25.00M, City = "Atlanta", ZIP = "30301", AvailableUntil = new DateTime(2025, 11, 25), Sold = false },
    new Plant() { Species = "Snake Plant", LightNeeds = 2, AskingPrice = 15.50M, City = "New York", ZIP = "10001", AvailableUntil = new DateTime(2025, 10, 20), Sold = false },
    new Plant() { Species = "Cactus", LightNeeds = 5, AskingPrice = 12.75M, City = "Phoenix", ZIP = "85001", AvailableUntil = new DateTime(2022, 10, 20), Sold = true },
    new Plant() { Species = "Fern", LightNeeds = 1, AskingPrice = 18.00M, City = "Seattle", ZIP = "98101", AvailableUntil = new DateTime(2025, 03, 22), Sold = false },
    new Plant() { Species = "Aloe Vera", LightNeeds = 4, AskingPrice = 20.00M, City = "Miami", ZIP = "33101", AvailableUntil = new DateTime(2022, 12, 14), Sold = true },
    new Plant() { Species = "Peace Lily", LightNeeds = 2, AskingPrice = 22.00M, City = "Chicago", ZIP = "60601", AvailableUntil = new DateTime(2025, 10, 16), Sold = false },
    new Plant() { Species = "Rubber Plant", LightNeeds = 3, AskingPrice = 30.00M, City = "Los Angeles", ZIP = "90001", AvailableUntil = new DateTime(2025, 11, 20), Sold = false },
    new Plant() { Species = "Bamboo Palm", LightNeeds = 4, AskingPrice = 27.50M, City = "Houston", ZIP = "77001", AvailableUntil = new DateTime(2022, 10, 20), Sold = true },
    new Plant() { Species = "ZZ Plant", LightNeeds = 1, AskingPrice = 19.99M, City = "Denver", ZIP = "80201", AvailableUntil = new DateTime(2026, 10, 20), Sold = false },
    new Plant() { Species = "Fiddle Leaf Fig", LightNeeds = 5, AskingPrice = 45.00M, City = "San Francisco", ZIP = "94101", AvailableUntil = new DateTime(2026, 01, 19), Sold = true },
};  

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
5. Plant of the day
6. Search for a plant by light needs
7. App statistics
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
            DelistPlant();
        }
        else if (choice == "5")
        {
            RandomPlant();
        }
        else if (choice == "6")
        {
            SearchPlant();
        }
        else if (choice == "7")
        {
            Statistics();
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

string PlantDetails(Plant plant)
{
    return $"Species: {plant.Species}\nLight Needs: ({plant.LightNeeds}/5)\nPrice: ${plant.AskingPrice:F2}\nLocation: {plant.City}\nZIP: {plant.ZIP}\nAvailable Until: {plant.AvailableUntil:MM/dd/yyyy}";
}

void Statistics()
{
    Console.WriteLine(@"
General statistics about the plants listed: 
    ");

    // Var per each stat
    Plant lowestPricePlant = plants[0];
    int availablePlants = 0;
    Plant lightNeeds = plants[0];
    int totalLightNeeds = 0;
    int adoptedPlants = 0;

    foreach (Plant plant in plants)
    {
        if (plant.AskingPrice < lowestPricePlant.AskingPrice)
        {
            lowestPricePlant = plant;
        }
        if (!plant.Sold)
        {
            availablePlants++;
        }
        if (plant.LightNeeds > lightNeeds.LightNeeds)
        {
            lightNeeds = plant;
        }

        totalLightNeeds+= plant.LightNeeds;
        if (plant.Sold)
        {
            adoptedPlants++;
        } 
    }
    double avgLightNeeds = (double)totalLightNeeds / plants.Count;
    decimal adoptionPercentage = (decimal)adoptedPlants / plants.Count * 100;

    Console.WriteLine($"1. The lowest price plant is {lowestPricePlant.Species} at ${lowestPricePlant.AskingPrice}.");
    Console.WriteLine($"2. The number of plants available is: {availablePlants} plants.");
    Console.WriteLine($"3. The plant with highest light needs is: {lightNeeds.Species}.");
    Console.WriteLine($"4. The average light needs for the plants listed is: {avgLightNeeds:F2}.");
    Console.WriteLine($"5. The percentage of adopted plants is: %{adoptionPercentage:F2}.");
}

void SearchPlant()
{
    Console.WriteLine("To search for a plant by light need, enter a number between 1 & 5: ");

    List<Plant> userPlants = new List<Plant>();

    string input = Console.ReadLine();
    int lightNeed;
    if (!int.TryParse(input, out lightNeed) || lightNeed < 1 || lightNeed > 5)
    {
        Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
        return;
    }
    foreach (Plant plant in plants)
    {
        if (plant.LightNeeds <= lightNeed)
        {
            userPlants.Add(plant);
        }
    }

    if (userPlants.Count > 0)
    {
        Console.WriteLine($"Here are the plants with light needs of {lightNeed}/5 or lower:");
        for (int i = 0; i < userPlants.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {PlantDetails(plants[i])}");
        }
    }
    else
    {
        Console.WriteLine($"There are no plants with light needs of {lightNeed}/5 or lower.");
    }
}

void ListPlants()
{
        Console.WriteLine("Plants:");

        for (int i = 0; i < plants.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {PlantDetails(plants[i])}");
        }
}

void PostPlant()
{
    Console.WriteLine("To post a plant, please enter the plant species first: ");
    string species = Console.ReadLine();

    Console.WriteLine("Enter the plant's light needs (1 for shade, 5 for full sun): ");
    int lightNeeds;
    while (!int.TryParse(Console.ReadLine(), out lightNeeds) || lightNeeds < 1 || lightNeeds > 5) 
    {
        Console.WriteLine("Invalid input. Please enter a number between 1 & 5 only.");
    }

    Console.WriteLine("Enter the asking price: ");
    decimal askingPrice;
    while (!decimal.TryParse(Console.ReadLine(), out askingPrice) || askingPrice < 0)
    {
        Console.WriteLine("Invalid input. Please enter a valid price.");
    }

    Console.WriteLine("Enter the city: ");
    string city = Console.ReadLine();

    Console.WriteLine("Enter the zip: ");
    string zip = Console.ReadLine();
    
    DateTime availableUntil;
    while (true)
    {
        try 
        {
            Console.WriteLine("Available until? Enter the year first (e.g. 2025): ");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Now enter the month (e.g. 01-12): ");
            int month = int.Parse(Console.ReadLine());

            Console.WriteLine("Lastly enter the day (e.g. 01-31): ");
            int day = int.Parse(Console.ReadLine());

            availableUntil = new DateTime(year, month, day);
            break;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid date. Please enter a valid year, month and day.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter numbers only.");
        }
    }

    plants.Add(new Plant() 
    { 
        Species = species,
        LightNeeds = lightNeeds,
        AskingPrice = askingPrice,
        City = city, 
        ZIP = zip, 
        AvailableUntil = availableUntil, 
        Sold = false 
    });
    Console.WriteLine($"Successfully added {species} to the plant list!");
}

void AdaptPlant()
{
    Console.WriteLine("To adapt a plant, please enter the number from the following available plants: ");

    List<int> availableIndices = new List<int>();

    for (int i = 0; i < plants.Count; i++)
    {
        if(!plants[i].Sold && plants[i].AvailableUntil > DateTime.Now)
        {
            Console.WriteLine($"{i + 1}. {PlantDetails(plants[i])}");
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
}


void availablePlants()
{
    Console.WriteLine("Here are available plants for adaption: ");
    bool hasAvailablePlants = false;
    for (int i = 0; i < plants.Count; i++)
    {
        if(!plants[i].Sold)
        {
          Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} is available for {plants[i].AskingPrice}$.");
          hasAvailablePlants = true;
        }
    }

    if (!hasAvailablePlants)
    {
        Console.WriteLine("There are no plants available for adaption atm.");
        // break;
    }
}

void DelistPlant()
{
    ListPlants();
    Console.WriteLine("\nTo delist a plant, please enter a plant number: ");

    string input = Console.ReadLine();
    int plantNumber;

    if (int.TryParse(input, out plantNumber) && plantNumber > 0 && plantNumber <= plants.Count)
    {
        int indexToRemove = plantNumber - 1;
        Console.WriteLine($"Are you sure you want to delist {plants[indexToRemove].Species}? (y/n) ");
        string confirmation = Console.ReadLine().Trim().ToLower();

        if (confirmation == "y")
        {
            plants.RemoveAt(indexToRemove);
            Console.WriteLine("Plant successfully delisted.");
        }
        else 
        {
            Console.WriteLine("Delisting canceled.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid plant number.");
    }

}

void RandomPlant()
{
    if (plants.All(p => p.Sold))
    {
        Console.WriteLine("No available plants for the day.");
        return; 
    }
    Plant selectedPlant;
    do
    {
        int randomIndex = randomPlant.Next(0, plants.Count);
        selectedPlant = plants[randomIndex];
    }
    while (selectedPlant.Sold || selectedPlant.AvailableUntil <= DateTime.Now); 
        Console.WriteLine($"Plant of the Day: {PlantDetails(selectedPlant)}");
}
