// See https://aka.ms/new-console-template for more information

using CPRG211Assignment1;
using CPRG211Assignment1.Properties;
using System.Runtime.CompilerServices;

string[] lines = Resources.appliances.Split(char.Parse("\n"));

List<Appliance> appliances = new List<Appliance>();

foreach (var line in lines)
{
    Console.WriteLine(line);
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

public void menu()
{
    Console.WriteLine("Hello and welcome to Modern Appliances");
    Console.WriteLIne("PLease enter a number to navigate the store");
    Console.WriteLine("1: Check out our appliances");
    Console.WriteLine("2: Serch appliances by brand");
    Console.WriteLine("3: Search appliances by type");
    Console.WriteLine("4: Generate a random list of appliances");
    Console.WriteLine("5: Save your selection and exit");
}

public void Purchasebynumber()
{
    Console.WriteLine("1: Refrigerators");
    Console.WriteLine("2: Vaccums");
    Console.WriteLine("3: Microwaves");
    Console.WriteLine("4: Dishwashers");
    Console.WriteLine("Please enter your selection");
    string applianceid == Console.ReadLine();
      if (applianceid > 0 || applianceid < 4 );
      {
          switch ()
      }
    else (Console.WriteLine("Entered number does not match any appliance type"));
    return;
}

public void Purchasebybrand()
{
    string selectbrand == Console.ReadLIne();
    if (selectbrand == brand)
    {
        Console.WriteLine();
    }
    else (Console.WriteLine("Unkown brand"));
}

public void Random()
{
    static Random rndapp = new Random();
    int rndamt == Console.ReadLine();
    int rndamt == rnd.Next(Appliance.Count);
    Console.WriteLine();
}

public void Exit()
{
    StreamWriter exit = new StreamWriter("C:\\appliances.txt");
    exit.StreamWriter($"ToString");
    exit.Close();
}

//Test to ensure appliance list is populated properly.
//Not part of final solution.
int lineNum = 1;
foreach (var appliance in appliances)
{
    Console.WriteLine($"\nSource File Line {lineNum}");
    lineNum++;
    Console.WriteLine(appliance);
}
