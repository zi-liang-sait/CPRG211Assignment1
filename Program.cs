﻿// See https://aka.ms/new-console-template for more information

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

public class Purchasebynumber
{
  string applianceid == Console.ReadLine();
      if (applianceid == number);
      {
          if (quantity > 0)
          {
              Console.WriteLine();
          }

          else (Console.WriteLine("The selected appliance is currently out of stock"));
      }
    else (Console.WriteLine("Entered number does not match any appliance ID"));
}

public class Purchasebybrand
{
    string selectbrand == Console.ReadLIne();
    if (selectbrand == brand)
    {
        Console.WriteLine();
    }
    else (Console.WriteLine("Unkown brand"));
}

public class Random
{
    static Random rndapp = new Random();
    int rndamt == Console.ReadLine();
    int rndamt == rnd.Next(Appliance.Count);
    Console.WriteLine();
}

public class Exit
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
