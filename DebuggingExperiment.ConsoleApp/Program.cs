using System;
using DebuggingExperiment.BusinessLayer;
using DebuggingExperiment.Models;

Console.WriteLine("\n   ORDER PROCESSING SYSTEM - VERIFICATION RUN    \n");

var order = new Order(new Customer { Name = "Alex de Vries" });

order.AddItem(new OrderItem("Toetsenbord", 30.00m, true));
order.AddItem(new OrderItem("Muismat", 10.00m, false)); 
order.AddItem(new OrderItem("Webcam", 45.00m, true));
order.AddItem(new OrderItem("USB Kabel", 5.00m, true));

var processor = new OrderProcessor();
decimal finalPrice = processor.CalculateTotal(order);

Console.WriteLine($"Aantal items in bestelling: {order.Items.Count}");
Console.WriteLine("--------------------------------------------------");
Console.WriteLine("VERWACHTE TOTAALPRIJS : € 80.00");
Console.WriteLine($"ACTUELE TOTAALPRIJS   : € {finalPrice:F2}");
Console.WriteLine("--------------------------------------------------");

if (finalPrice == 80.00m)
{
    Console.WriteLine("RESULTAAT: SUCCESS - Systeem werkt correct!");
}
else
{
    Console.WriteLine("RESULTAAT: FOUT - De berekende totaalprijs is onjuist!");
    Console.WriteLine("OPDRACHT VOOR STUDENT: Vind de exacte regel en oorzaak van deze afwijking.");
}

Console.ReadLine();