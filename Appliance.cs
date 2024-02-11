using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211Assignment1
{
    internal abstract class Appliance(string number, string brand, int quantity, int wattage, string color, double price)
    {
        public string? ItemNumber { get; set; } = number;
        public string? Brand { get; set; } = brand;
        public int Quantity { get; set; } = quantity;
        public int Wattage { get; set; } = wattage;
        public string? Color { get; set; } = color;
        public double Price { get; set; } = price;

        public void CheckOut()
        {
            if (this.Quantity > 0)
            {
                this.Quantity--;
                Console.WriteLine($"Appliance \"{this.ItemNumber}\" has been checked out.");
            }
            else
            {
                Console.WriteLine("This appliance is not available to be checked out.");
            }
        }

        public abstract string FormatFile();

        public override string ToString()
        {
            return $"ItemNumber: {this.ItemNumber}\n" +
                $"Brand: {this.Brand}\n" +
                $"Quantity: {this.Quantity}\n" +
                $"Wattage: {this.Wattage}\n" +
                $"Color: {this.Color}\n" +
                $"Price: {this.Price}\n";
        }
    }
}
