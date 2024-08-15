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
        LightNeeds = 1,
        AskingPrice = 15.00M,
        City = "San Antonio",
        ZIP = 78201,
        Sold = true
    }
};

Console.Clear();

string greeting = @"🌿 Welcome to ExtraVert! 🌱
Explore, list, and buy secondhand plants with ease.";
Console.WriteLine(greeting);

Console.WriteLine("Press any key to enter");
Console.ReadKey(); 
Console.Clear();

string choice = null;
while (choice != "e") 
{
    Console.WriteLine(@"🌿 ExtraVert 🌱
Choose an option:
    a. Display all plants
    b. Post a plant to be adopted
    c. Adopt a plant
    d. Delist a plant
    e. Exit");

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
            throw new NotImplementedException("Adopt a plant");
        case "d":
            Console.Clear();
            throw new NotImplementedException("Delist a plant");
        case "e":
            Console.Clear();
            Console.WriteLine("Goodbye!");
            break;
        default:
            Console.Clear();
            Console.WriteLine("Invalid choice, please choose from the options shown.");
            break;
    }

}

void ListPlants()
{
    Console.WriteLine(@"🌿 ExtraVert 🌱 
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
    Console.WriteLine(@"🌿 ExtraVert 🌱 
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
                    Console.WriteLine("Please enter a number between 1 and 5.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please type only integers!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Do Better!");
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
            Console.WriteLine("Please enter a valid decimal number.");
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
            Console.WriteLine("Please enter a valid integer for zip code.");
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
    Console.WriteLine(@$"Plant added successfully!
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