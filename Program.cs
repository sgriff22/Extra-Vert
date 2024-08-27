List <Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Fiddle Leaf Fig",
        LightNeeds = 1,
        AskingPrice = 25.50M,
        City = "Nashville",
        ZIP = 37167,
        Sold = false,
        AvailableUntil = new DateTime(2024, 9, 20),
        PlantType = "herb"
    },
    new Plant()
    {
        Species = "Snake Plant",
        LightNeeds = 1,
        AskingPrice = 30.75M,
        City = "Austin",
        ZIP = 73301,
        Sold = false,
        AvailableUntil = new DateTime(2024, 10, 20),
        PlantType = "bush"
    },
    new Plant()
    {
        Species = "Granny Smith Apple",
        LightNeeds = 2,
        AskingPrice = 20.50M,
        City = "Dallas",
        ZIP = 75201,
        Sold = false,
        AvailableUntil = new DateTime(2024, 3, 20),
        PlantType = "tree"
    },
    new Plant()
    {
        Species = "Peace Lily",
        LightNeeds = 3,
        AskingPrice = 35.75M,
        City = "Nashville",
        ZIP = 37167,
        Sold = false,
        AvailableUntil = new DateTime(2024, 11, 20),
        PlantType = "flower"
    },
    new Plant()
    {
        Species = "Aloe Vera",
        LightNeeds = 5,
        AskingPrice = 15.00M,
        City = "San Antonio",
        ZIP = 78201,
        Sold = true,
        AvailableUntil = new DateTime(2024, 9, 17),
        PlantType = "bush"
    }
};

//PLANT OF THE DAY
// Create a Random object
Random random = new Random();
// Select a random available plant
Plant randomPlant = null;
while (randomPlant == null || randomPlant.Sold)
{
// Generate a random index for the plants list
int randomIndex = random.Next(plants.Count);
// Select a random plant
randomPlant = plants[randomIndex];
}

Console.Clear();

string greeting = @"🌿 Welcome to ExtraVert! 🌱
Explore, list, and buy secondhand plants with ease.";
Console.WriteLine(greeting);

string logo = "🌿 ExtraVert 🌱";

Console.WriteLine("\nPress any key to enter");
Console.ReadKey(); 
Console.Clear();

string choice = null;
while (choice != "i") 
{
    Console.WriteLine(@$"{logo}
Choose an option:
    a. Display all plants
    b. Post a plant to be adopted
    c. Adopt a plant
    d. Delist a plant
    e. Plant of the Day
    f. Search plants by light needs
    g. View plant stats
    h. Plants by Species
    i. EXIT");

    choice = Console.ReadLine();

    switch (choice)
    {
        case "a":
            Console.Clear();
            ListPlants();
            break;
        case "b":
            Console.Clear();
            CreatePlant();
            break;
        case "c":
            Console.Clear();
            AdoptPlant();
            break;
        case "d":
            Console.Clear();
            RemovePlant();
            break;
        case "e":
            Console.Clear();
            Console.WriteLine(@$"🌿 Plant of the Day 📅
Species: {randomPlant.Species}
Location: {randomPlant.City}, ZIP: {randomPlant.ZIP}
Light Needs: {randomPlant.LightNeeds}
Asking Price: {randomPlant.AskingPrice:C}
PlantType: {randomPlant.PlantType}");
         
            ReturnMenu();
            break;
        case "f":
            Console.Clear();
            SearchPlants();
            break;
        case "g":
            Console.Clear();
            PlantStats();
            break;
        case "h":
            Console.Clear();
            InventoryBySpecies();
            break;
        case "i":
            Console.Clear();
            Console.WriteLine("👋 Goodbye!");
            break;
        default:
            Console.Clear();
            Console.WriteLine("❗Invalid choice, please choose from the options shown.");
            break;
    }

}

void ListPlants()
{
    Console.WriteLine(@$"{logo}
ALL PLANTS");
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine(PlantDetails(plants[i], i));
    }
  
    ReturnMenu();
}

void CreatePlant()
{
    Console.Clear();
    Console.WriteLine(@$"{logo}
POST A PLANT");

    //PLANT TYPE
    string[] plantTypes =
    {
        "tree",
        "bush",
        "flower", 
        "herb"
    };
    Console.WriteLine("Choose the plant type:");
    for (int i = 0; i < plantTypes.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {plantTypes[i]}");
    }
    int typeChoice = GetValidInteger(1, plantTypes.Length, "Please enter a number between 1 and 4." );
    string plantType = plantTypes[typeChoice - 1];

    //SPECIES
    string species = GetValidString("Enter the plant species: ");
    
    //LIGHT NEEDS
    Console.WriteLine(@"How much light does the plant need?
1 (Shade) - 5 (Full Sun)");
    int light = GetValidInteger(1, 5, "Please enter a number between 1 and 5.");
    
    //ASKING PRICE
    bool validPriceInput = false; 
    decimal price = 0.0M;
    while (!validPriceInput)
    {
        Console.WriteLine("Enter an asking price: ");

        try
        {
            price = decimal.Parse(Console.ReadLine().Trim());
            validPriceInput = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("❗Please enter a valid decimal number.");
        }
    }

    //CITY
    string city = GetValidString("Enter the city where the plant is sold: ");

    //ZIP
    Console.WriteLine("Enter zip code: ");
    int zip = GetValidInteger(10000, 99999, "ZIP code should be a 5-digit number.");

    //AVAILABLE UNTIL
    int year = 0;
    int month = 0;
    int day = 0;
    DateTime date = DateTime.MinValue;
    bool validDateInput = false;
    while (!validDateInput)
    {
        Console.WriteLine("Enter the plants expiration date: ");
        try
        {
            Console.WriteLine("Year:");
            year = int.Parse(Console.ReadLine().Trim());
            Console.WriteLine("Month:");
            month = int.Parse(Console.ReadLine().Trim());
            Console.WriteLine("Day:");
            day = int.Parse(Console.ReadLine().Trim());
            // Try to create a DateTime object to validate the date
            date = new DateTime(year, month, day);
            validDateInput = true;
        }
         catch (FormatException)
        {
            Console.WriteLine("❗Please enter valid integers for year, month, and day.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine(@"❗The date you entered is out of range.
❗Months should be between 1 and 12.
❗Days should be between 1 and 31, depending on the month and leap year status.");
        }
    }

    //Create new plant
    Plant newPlant = new Plant
    {
        Species = species,
        LightNeeds = light,
        AskingPrice = price,
        City = city,
        ZIP = zip,
        Sold = false,
        AvailableUntil = date,
        PlantType = plantType
    };

    plants.Add(newPlant);

    Console.Clear();
    Console.WriteLine(@$"🌟 Plant added successfully! 🌟 
    Species: {species}
    Light Needed: {light}
    Asking Price: {price}
    City: {city}
    ZIP: {zip}
    Sold: false
    Available Until: {date:MM/dd/yyyy}
    Plant Type: {plantType}");
    ReturnMenu();
}

void AdoptPlant()
{
    Console.Clear();
    Console.WriteLine(@$"{logo}
ADOPT A PLANT");

    // Get the current date and time
    DateTime now = DateTime.Now;

    //Display all available plants
    List<Plant> availablePlants = plants.FindAll(p => !p.Sold && p.AvailableUntil >= now);

    //if no available plants add a message
    if (availablePlants.Count == 0)
    {
        Console.WriteLine("😞 No plants are currently available for adoption.");
        ReturnMenu();
    }

    for (int i = 0; i < availablePlants.Count; i++)
    {
        DateTime newDate = availablePlants[i].AvailableUntil;
        Console.WriteLine(PlantDetails(plants[i], i));
        Console.WriteLine($"   Listing Expires: {newDate:MM/dd/yyyy}");
    }

    Console.WriteLine("Enter the number of the plant you want to adopt (or 0 to cancel): ");
    int choice = GetValidInteger(0, availablePlants.Count, "❗Please enter a valid number corresponding to the plant.");

    if (choice == 0)
    {
        Console.Clear();
        Console.WriteLine("❌ Adoption process cancelled.");
    }
    else 
    {
        Plant selectedPlant = availablePlants[choice -1];
        selectedPlant.Sold = true;

        Console.Clear();
        Console.WriteLine(@$"🎉 Congratulations on adopting your new plant! 🎉
You have successfully adopted:
    - Species: {selectedPlant.Species}
    - City: {selectedPlant.City}
    - Asking Price: {selectedPlant.AskingPrice:C}
Thank you for adopting from ExtraVert!");

    }
    ReturnMenu();
}

void RemovePlant()
{
    Console.WriteLine(@$"{logo}
REMOVE PLANT");

    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine(PlantDetails(plants[i], i));
    }

    Console.WriteLine("Enter the number of the plant you want to remove (or 0 to cancel): ");
    
    int choice = GetValidInteger(0, plants.Count, "❗Please enter a valid number corresponding to the plant.");

    if (choice == 0)
    {
        Console.Clear();
        Console.WriteLine("❌ Operation cancelled.");
    }
    else 
    {
        // Capture the plant information before removing it
        Plant removedPlant = plants[choice - 1];

        // Remove the plant from the list (adjusting for zero-based index)
        plants.RemoveAt(choice - 1);

        Console.Clear();
        Console.WriteLine(@$"🌟 Plant Successfully Removed! 🌟");
        Console.WriteLine(@$"You have successfully removed the following plant:
- Species: {removedPlant.Species}
- City: {removedPlant.City}
- Asking Price: {removedPlant.AskingPrice:C}
Thank you for updating our plant inventory!");
    }                 
    ReturnMenu();
}
    


void SearchPlants()
{
    Console.Clear();
    Console.WriteLine(@$"{logo}
PLANT SEARCH");
    Console.WriteLine(@"Enter your maximum light needs number
1 (Shade) - 5 (Full Sun)");

    int response = GetValidInteger(1, 5, "❗Please enter a number between 1 and 5.");
   
    List<Plant> plantsFound = plants.Where(p => p.LightNeeds <= response).ToList();

    //Display the filtered plants 
    if (plantsFound.Count == 0) 
    {
        Console.WriteLine("😞 No plants match your light needs criteria.");
    }
    else
    {
        Console.WriteLine($"Plants with light needs up to {response}:");
        int index = 1;
        foreach (Plant plant in plantsFound)
        {
            Console.WriteLine(@$"{PlantDetails(plant, index-1)} 
   Light Needs: {plant.LightNeeds}");
            index++;
        }
    }

    ReturnMenu();
}

void PlantStats()
{
    Console.WriteLine(@$"{logo}
PLANT STATS");

    //Lowest Price
    Plant lowestPricedPlant = null;
    decimal lowestPrice = decimal.MaxValue;

    for (int i = 0; i < plants.Count; i++)
    {
        if (plants[i].AskingPrice < lowestPrice)
        {
            lowestPrice = plants[i].AskingPrice;
            lowestPricedPlant = plants[i];
        }
    }
    Console.WriteLine($"💲 Lowest priced: {lowestPricedPlant.Species}");

    //Highest Price
    Plant highestPricedPlant = null;
    decimal highestPrice = decimal.MinValue;

    for (int i = 0; i < plants.Count; i++)
    {
        if (plants[i].AskingPrice > highestPrice)
        {
            highestPrice = plants[i].AskingPrice;
            highestPricedPlant = plants[i];
        }
    }
    Console.WriteLine($"💲 Highest priced: {highestPricedPlant.Species}");

    //Highest Light
    Plant highestLightPlant = null;
    int highestLight = int.MinValue;

    for (int i = 0; i < plants.Count; i++)
    {
        if (plants[i].LightNeeds > highestLight)
        {
            highestLight = plants[i].LightNeeds;
            highestLightPlant = plants[i];
        }
    }
    Console.WriteLine($"💡 Highest light needs: {highestLightPlant.Species}");
   

    //Average Light
    int totalLightNeeds = 0;

    for(int i = 0; i < plants.Count; i++)
    {
        totalLightNeeds += plants[i].LightNeeds;
    }
    double averageLight = (double)totalLightNeeds / plants.Count;
    Console.WriteLine($"💡 Average light needs: {averageLight:F1}");

    //Percentage of plants adopted
    int totalAdopted = 0;

    for(int i = 0; i < plants.Count; i++)
    {
        if (plants[i].Sold)
        {
            totalAdopted ++;
        }
    }
    double adoptedPercentage = (double)totalAdopted / plants.Count * 100;
    Console.WriteLine($"🎉 Plants Adopted: {adoptedPercentage:F1}%");
  
    ReturnMenu();
}


string PlantDetails(Plant plant, int index)
{
    string plantString = $"{index + 1}. {plant.Species} in {plant.City} {(plant.Sold ? "was sold" : "is available")} for {plant.AskingPrice:C}. Type: {plant.PlantType}";

    return plantString;
}

void ReturnMenu()
{
    Console.WriteLine("\nPress any key to go back to Menu");
    Console.ReadKey();
    Console.Clear();
}

void InventoryBySpecies()
{
    Dictionary<string, int> plantSpecies = new Dictionary<string, int>();

    foreach (Plant plant in plants)
    {
        if (plantSpecies.ContainsKey(plant.Species))
        {
            plantSpecies[plant.Species]++;
        }
        else
        {
            plantSpecies.Add(plant.Species, 1);
        }
    }

    foreach (KeyValuePair<string, int> kv in plantSpecies)
    {
        Console.WriteLine($"Species: {kv.Key}, Count: {kv.Value}");
    }

    ReturnMenu();
}

int GetValidInteger(int min, int max, string errorMessage)
{
    int value;
    while(true)
    {
        try
        {
            value = int.Parse(Console.ReadLine().Trim());
            if (value >= min && value <= max)
            {
                return value;
            }
             Console.WriteLine(errorMessage);
        }
        catch (FormatException)
        {
            Console.WriteLine("❗Please type only integers!");
        }
    }
}

string GetValidString(string prompt)
{
    while(true)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine().Trim();

        try
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ValidationException("Input cannot be empty.");
            }
            else if (input.Length > 50)
            {
                throw new ValidationException("Input is too long. It must be less than 50 characters.");
            }
            else
            {
                return input;
            }
        }
        catch (ValidationException ex)
        {
            Console.WriteLine($"❗{ex.Message}");
        }
    }
}


public class ValidationException : Exception
{
    public ValidationException(string message) : base(message)
    {

    }
}