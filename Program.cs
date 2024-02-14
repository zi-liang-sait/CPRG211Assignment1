// See https://aka.ms/new-console-template for more information

using CPRG211Assignment1;
using CPRG211Assignment1.Properties;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

//public enum Options
//{
//    None,
//    Checkout = 1,
//    FindBrand = 2,
//    AppType = 3,
//    RandomList = 4,
//    SaveExit = 5,
//}

Random randomNum = new Random();
List<Appliance> appliances = GetAppliancesFromString(Resources.appliances);
DisplayMenu(appliances);

static List<Appliance> GetAppliancesFromString(string applianceInfo)
{
    string[] lines = applianceInfo.Split(char.Parse("\n"));

    List<Appliance> appliances = new List<Appliance>();

    foreach (var line in lines)
    {
        //Next line is for debugging.
        //Console.WriteLine(line);
        string[] info = line.Split(char.Parse(";"));

        //To skip the final blank line
        if (info.Length < 6)
        {
            break;
        }

        switch (line[0])
        {
            case '1':
                appliances.Add(new Refrigerator(info[0], info[1], int.Parse(info[2]), int.Parse(info[3]), info[4], double.Parse(info[5]), int.Parse(info[6]), double.Parse(info[7]), double.Parse(info[8])));
                break;
            case '2':
                appliances.Add(new Vacuum(info[0], info[1], int.Parse(info[2]), int.Parse(info[3]), info[4], double.Parse(info[5]), info[6], int.Parse(info[7])));
                break;
            case '3':
                appliances.Add(new Microwave(info[0], info[1], int.Parse(info[2]), int.Parse(info[3]), info[4], double.Parse(info[5]), double.Parse(info[6]), char.Parse(info[7])));
                break;
            case '4':
            case '5':
                appliances.Add(new Dishwasher(info[0], info[1], int.Parse(info[2]), int.Parse(info[3]), info[4], double.Parse(info[5]), info[6], info[7]));
                break;
            default:
                break;
        }
    }
    return appliances;
}

void DisplayMenu(List<Appliance> appliances)
{
    Console.WriteLine("Hello and welcome to Modern Appliances!");
    Console.WriteLine("How may we assist you?");
    Console.WriteLine("1: Check out appliance");
    Console.WriteLine("2: Find appliances by brand");
    Console.WriteLine("3: Display appliances by type");
    Console.WriteLine("4: Produce random appliance list");
    Console.WriteLine("5: Save & exit");
    Console.WriteLine("Enter option:");
    string? menuChoice = Console.ReadLine();
    switch (menuChoice)
    {
        case "1":
            Console.WriteLine("Enter item number of an Appliance:");
            string? itemNumber = Console.ReadLine();
            CheckOutApplianceByNumber(itemNumber, appliances);
            DisplayMenu(appliances);
            break;
        case "2":
            BrowseByBrand(appliances);
            DisplayMenu(appliances);
            break;
        case "3":
            BrowseByType(appliances);
            DisplayMenu(appliances);
            break;
        case "4":  
            BrowseRandomly(appliances);
            DisplayMenu(appliances);
            break;
        case "5":
            Save(appliances);
            break;
        default: Console.WriteLine("Invalid menu option.");
            DisplayMenu(appliances);
            break;
    }
}

static void CheckOutApplianceByNumber(string itemNumber, List<Appliance> appliances)
{
    Appliance appliance = FindApplianceByNumber(itemNumber, appliances);
    if (appliance == null)
    {
        Console.WriteLine("No appliances found with that item number.");
    }
    else
    {
        appliance.CheckOut();
    }
}

static Appliance? FindApplianceByNumber(string itemNumber, List<Appliance> appliances)
{
    foreach (Appliance appliance in appliances)
    {
        if (appliance.ItemNumber == itemNumber) 
        { 
            return appliance; 
        }
    }
    return null;
}

static List<Appliance> FindAppliancesByBrand(string brand, List<Appliance> appliances)
{
    List<Appliance> foundAppliances = new List<Appliance>();

    foreach (Appliance appliance in appliances)
    {
        if (appliance.Brand.ToLower() == brand.ToLower()) 
        {
            foundAppliances.Add(appliance);
        }
    }
    return foundAppliances;
}

static List<Appliance> FindAppliancesByType(string type, string option, List<Appliance> appliances)
{
    List<Appliance> foundAppliances = new List<Appliance>();

    foreach (Appliance appliance in appliances)
    {
        if (appliance is Refrigerator && type == "1")
        {
            Refrigerator refrigerator = (Refrigerator)appliance;
            if (refrigerator.NumberOfDoors.ToString() == option)
            {
                foundAppliances.Add(appliance);
            }
        }
        else if (appliance is Vacuum && type == "2")
        {
            Vacuum vacuum = (Vacuum)appliance;
            if (vacuum.BatteryVoltage.ToString() == option)
            {
                foundAppliances.Add(appliance);
            }
        }
        else if (appliance is Microwave && type == "3")
        {
            Microwave microwave = (Microwave)appliance;
            if (microwave.RoomType.ToString() == option)
            {
                foundAppliances.Add(appliance);
            }
        }
        else if (appliance is Dishwasher && type == "4")
        {
            Dishwasher dishwasher = (Dishwasher)appliance;
            if (dishwasher.SoundRating == option)
            {
                foundAppliances.Add(appliance);
            }
        }
    }
    return foundAppliances;
}

//Clones the list, then removes appliances from the new list until the correct number is left.
//If "number" is less than 1, doesn't find any appliances.
//Cannot find more appliances than there is total in the input list.
//Random Number reference: https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-integer-in-c
List<Appliance> FindRandomAppliances(int number, List<Appliance> appliances)
{
    List<Appliance> appliancesClone = new List<Appliance>(appliances);
    for (int i = 0; i < appliances.Count - number; i++)
    {
        appliancesClone.RemoveAt(randomNum.Next(0, appliancesClone.Count));
        if (appliancesClone.Count == 0)
        {
            break;
        }
    }
    return appliancesClone;
}

static void Save(List<Appliance> appliances)
{
    //Output file named differently to avoid overwriting original source file.
    //Output file path: (Windows user folder)\repos\CPRG211Assignment1\bin\Debug\net8.0\Folder\appliances1.txt'
    using (StreamWriter sw = new StreamWriter("appliances1.txt"))
    {
        foreach (Appliance appliance in appliances)
        {
            sw.WriteLine(appliance.FormatFile());
        }
    }
}

static void BrowseByType(List<Appliance> appliances)
{
    Console.WriteLine("Appliance Types");
    Console.WriteLine("1: Refrigerators");
    Console.WriteLine("2: Vaccums");
    Console.WriteLine("3: Microwaves");
    Console.WriteLine("4: Dishwashers");
    Console.WriteLine("Enter type of appliance:");

    string applianceType = Console.ReadLine();
    string? option = null;
    switch (applianceType)
    {
        case "1":
            Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
            option = Console.ReadLine();
            foreach (Appliance appliance in FindAppliancesByType(applianceType, option, appliances))
            {
                Console.WriteLine(appliance);
            }
            return;
        case "2":
            Console.WriteLine("Enter battery voltage value. 18 V(low) or 24 V(high)");
            option = Console.ReadLine();
            foreach (Appliance appliance in FindAppliancesByType(applianceType, option, appliances))
            {
                Console.WriteLine(appliance);
            }
            return;
        case "3":
            Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");
            option = Console.ReadLine();
            foreach (Appliance appliance in FindAppliancesByType(applianceType, option, appliances))
            {
                Console.WriteLine(appliance);
            }
            return;
        case "4":
            Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
            option = Console.ReadLine();
            foreach (Appliance appliance in FindAppliancesByType(applianceType, option, appliances))
            {
                Console.WriteLine(appliance);
            }
            return;
        default:
            Console.WriteLine("Invalid appliance type.");
            return;
    }
}

static void BrowseByBrand(List<Appliance> appliances)
{
    Console.WriteLine("Please brand to search for:");
    string brandChoice = Console.ReadLine();
    List<Appliance> foundAppliances = FindAppliancesByBrand(brandChoice, appliances);
    if (foundAppliances.Count == 0)
    {
        Console.WriteLine("No appliances found.");
        return;
    }
    foreach (Appliance appliance in foundAppliances)
    {
        Console.WriteLine(appliance);
    }
}

void BrowseRandomly(List<Appliance> appliances)
{
    Console.WriteLine("Enter number of appliances");
    string? numberChoice = Console.ReadLine();
    if (numberChoice == null)
    {
        Console.WriteLine($"Invalid number of appliances. Min: 1, Max: {appliances.Count}.");
        return;
    }
    int number = int.Parse(numberChoice);
    if (number < 1 || number > appliances.Count)
    {
        Console.WriteLine($"Invalid number of appliances. Min: 1, Max: {appliances.Count}.");
        return;
    }
    foreach (Appliance appliance in FindRandomAppliances(number, appliances)) { 
        Console.WriteLine(appliance);
    }
}

//static void ranList()
//{
//    static Random rndapp = new Random();
//    int rndamt == Console.ReadLine();
//    int rndamt == rnd.Next(Appliance.Count);
//    Console.WriteLine();
//}

//static void Exit()
//{

//    StreamWriter fileStream = File.CreateText("C:\\appliances.txt");

//    foreach (var appliance in appliances)
//    {
//        fileStream.WriteLine(appliance.FormatForFile());
//    }

//    exit.Close();

//    Console.WriteLine("Saving compleated!");
//}

//Test to ensure appliance list is populated properly.
//Not part of final solution.
//int lineNum = 1;
//foreach (var appliance in appliances)
//{
//    Console.WriteLine($"\nSource File Line {lineNum}");
//    lineNum++;
//    Console.WriteLine(appliance);
//}
