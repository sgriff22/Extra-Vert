List <Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Fiddle Leaf Fig",
        LightNeeds = 1,
        AskingPrice = 25.50M,
        City = "Nashville",
        ZIP = 37167,
        Sold = false
    },
    new Plant()
    {
        Species = "Snake Plant",
        LightNeeds = 1,
        AskingPrice = 30.75M,
        City = "Austin",
        ZIP = 73301,
        Sold = false
    },
    new Plant()
    {
        Species = "Spider Plant",
        LightNeeds = 2,
        AskingPrice = 20.50M,
        City = "Dallas",
        ZIP = 75201,
        Sold = false
    },
    new Plant()
    {
        Species = "Peace Lily",
        LightNeeds = 3,
        AskingPrice = 35.75M,
        City = "Nashville",
        ZIP = 37167,
        Sold = false
    },
    new Plant()
    {
        Species = "Aloe Vera",
        LightNeeds = 5,
        AskingPrice = 15.00M,
        City = "San Antonio",
        ZIP = 78201,
        Sold = true
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

Console.WriteLine("Press any key to enter");
Console.ReadKey(); 
Console.Clear();

string choice = null;
while (choice != "g") 
{
    Console.WriteLine(@$"{logo}
Choose an option:
    a. Display all plants
    b. Post a plant to be adopted
    c. Adopt a plant
    d. Delist a plant
    e. Plant of the Day
    f. Search plants by light needs
    g. EXIT");

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
Asking Price: {randomPlant.AskingPrice:C}");
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to Menu");
            Console.ReadKey(); 
            Console.Clear();
            break;
        case "f":
            Console.Clear();
            SearchPlants();
            break;
        case "g":
            Console.Clear();
            Console.WriteLine("Goodbye!");
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
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice} dollars");
    }
    // Add space between the list and the menu
    Console.WriteLine();
    Console.WriteLine("Press any key to go back to Menu");
    Console.ReadKey(); 
    Console.Clear();
}

void CreatePlant()
{
    Console.Clear();
    Console.WriteLine(@$"{logo}
POST A PLANT");

    //SPECIES
    Console.WriteLine("Enter the plant species: ");
    string species = Console.ReadLine().Trim();
    
    //LIGHT NEEDS
    int light = 0;
    bool validInput = false; 
    Console.WriteLine(@"How much light does the plant need?
    1 (Shade) - 5 (Full Sun)");
    
    while (!validInput)
        {
            try
            {
                light = int.Parse(Console.ReadLine().Trim());

                if (light >= 1 && light <= 5)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("❗Please enter a number between 1 and 5.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("❗Please type only integers!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("❗Do Better!");
            }
        }

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
    Console.WriteLine("Enter the city where the plant is sold: ");
    string city = Console.ReadLine().Trim();

    //ZIP
    int zip = 0;
    bool validZipInput = false;
    while (!validZipInput)
    {
        Console.WriteLine("Enter zip code: ");
        try
        {
            zip = int.Parse(Console.ReadLine().Trim());
            validZipInput = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("❗Please enter a valid integer for zip code.");
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
        Sold = false
    };

    plants.Add(newPlant);

    Console.Clear();
    Console.WriteLine(@$"🌟 Plant added successfully! 🌟 
    Species: {species}
    Light Needed: {light}
    Asking Price: {price}
    City: {city}
    ZIP: {zip}
    Sold: false");
    Console.WriteLine("Press any key to go back to Menu");
    Console.ReadKey();
    Console.Clear();
}

void AdoptPlant()
{
    Console.Clear();
    Console.WriteLine(@$"{logo}
ADOPT A PLANT");

    //Display all available plants
    List<Plant> availablePlants = plants.FindAll(p => !p.Sold);

    bool validInput = false;

    //if no available plants add a message
    if (availablePlants.Count == 0)
    {
        Console.WriteLine("😞 No plants are currently available for adoption.");
        Console.WriteLine("Press any key to go back to Menu");
        Console.ReadKey();
        Console.Clear();
        validInput = true;
    }

    for (int i = 0; i < availablePlants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {availablePlants[i].Species} is available in {availablePlants[i].City} for {availablePlants[i].AskingPrice} dollars");
    }

    //Get user response
    int choice = 0;
        
    Console.WriteLine("Enter the number of the plant you want to adopt (or 0 to cancel): ");

    while (!validInput)
    {
        try 
        {
            choice = int.Parse(Console.ReadLine().Trim());

            if (choice == 0)
            {
                validInput = true;
                Console.Clear();
                Console.WriteLine("❌ Adoption process cancelled.");
                Console.WriteLine("Press any key to go back to Menu");
                Console.ReadKey();
                Console.Clear();
            }
            else if (choice >= 1 && choice <= availablePlants.Count)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("❗Please enter a valid number corresponding to the plant.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("❗Please type only integers!");
        }
    }

    if (choice != 0)
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

        Console.WriteLine("Press any key to go back to Menu");
        Console.ReadKey();
        Console.Clear();
    }
}

void RemovePlant()
{
    Console.WriteLine(@$"{logo}
REMOVE PLANT");

    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice} dollars");
    }

    Console.WriteLine("Enter the number of the plant you want to remove (or 0 to cancel): ");
    bool validInput = false;

    while(!validInput) 
    {

        try
        {
            int choice = int.Parse(Console.ReadLine().Trim());

            if (choice == 0)
            {
                validInput = true;
                Console.Clear();
                Console.WriteLine("❌ Operation cancelled.");
                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
                Console.Clear();
            }
            else if (choice >= 1 && choice <= plants.Count)
            {
                // Capture the plant information before removing it
                Plant removedPlant = plants[choice - 1];

                // Remove the plant from the list (adjusting for zero-based index)
                plants.RemoveAt(choice - 1);
                validInput = true;

                Console.Clear();
                Console.WriteLine(@$"🌟 Plant Successfully Removed! 🌟");
                Console.WriteLine(@$"You have successfully removed the following plant:
    - Species: {removedPlant.Species}
    - City: {removedPlant.City}
    - Asking Price: {removedPlant.AskingPrice:C}
Thank you for updating our plant inventory!
Press any key to return to the menu.");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("❗Please enter a valid number corresponding to the plant.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("❗Please enter a valid integer.");
        }
    }
} 

void SearchPlants()
{
    Console.Clear();
    Console.WriteLine(@$"{logo}
PLANT SEARCH");
    Console.WriteLine(@"Enter your maximum light needs number
1 (Shade) - 5 (Full Sun)");
    int response = 0;

    bool validInput = false;

    while (!validInput)
    {
        try 
        {
            response = int.Parse(Console.ReadLine().Trim());

            if (response >= 1 && response <= 5)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("❗Please enter a number between 1 and 5.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("❗Please enter a valid integer.");
        }
    }

    //Create a new list to store the plants based off response
    List<Plant> plantsFound = new List<Plant>();

    //Filter through and store only the plants that fit response value
    foreach (Plant plant in plants)
    {
        if(plant.LightNeeds <= response) 
        {
            plantsFound.Add(plant);
        }
    }

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
            Console.WriteLine($"{index}. Light Needs: {plant.LightNeeds} - {plant.Species} in {plant.City} {(plant.Sold ? "was sold" : "is available")} for {plant.AskingPrice} dollars.");
            index++;
        }
    }

    Console.WriteLine();
    Console.WriteLine("Press any key to go back to Menu");
    Console.ReadKey();
    Console.Clear();
}