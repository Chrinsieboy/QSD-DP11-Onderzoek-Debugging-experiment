using System;
using DebuggingExperiment.BusinessLayer;
using DebuggingExperiment.Models;

Console.WriteLine("\n   PRODUCT ASSEMBLY SYSTEM - VERSIE B    \n");

var wielSet = new Component("Wiel Set (Geassembleerd)", 10.00m);
wielSet.Add(new Component("Autoband", 50.00m));
wielSet.Add(new Component("Sport Velg", 40.00m));

var auto = new Component("Sportwagen X", 5000.00m);

auto.Add(wielSet); 
auto.Add(wielSet); 
auto.Add(wielSet); 
auto.Add(wielSet); 

var calculator = new PriceCalculator();
decimal finalPrice = calculator.CalculateTotal(auto);

Console.WriteLine($"Product: {auto.Name}");
Console.WriteLine($"Aantal hoofdonderdelen gemonteerd: {auto.SubComponents.Count}");
Console.WriteLine("--------------------------------------------------");
Console.WriteLine("VERWACHTE TOTAALPRIJS : € 5400.00");
Console.WriteLine($"ACTUELE TOTAALPRIJS   : € {finalPrice:F2}");
Console.WriteLine("--------------------------------------------------");

if (Math.Abs(finalPrice - 5400.00m) < 0.01m)
{
    Console.WriteLine("RESULTAAT: SUCCESS - Systeem werkt correct!");
}
else
{
    Console.WriteLine("RESULTAAT: FOUT - De berekende totaalprijs is onjuist!");
}

Console.ReadLine();