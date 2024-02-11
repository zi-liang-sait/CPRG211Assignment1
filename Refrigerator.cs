using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211Assignment1
{
    internal class Refrigerator(string number, string brand, int quantity, int wattage, string color, double price, int numberOfDoors, double height, double width) : Appliance(number, brand, quantity, wattage, color, price)
    {
        public int NumberOfDoors { get; set; } = numberOfDoors;
        public double Height { get; set; } = height;
        public double Width { get; set; } = width;

        private string DoorDescription(int numberOfDoors)
        {
            switch (numberOfDoors)
            {
                case 2:
                    return "Two Doors";
                case 3:
                    return "Three Doors";
                case 4:
                    return "Four Doors";
                default:
                    return "Unknown";
            }
        }

        public override string FormatFile()
        {
            return $"{this.ItemNumber};{this.Brand};{this.Quantity};{this.Wattage};{this.Color};{this.Price};{this.NumberOfDoors};{this.Height};{this.Width};";
        }

        //Reference enum value by number: https://stackoverflow.com/questions/41666625/c-sharp-can-you-call-an-enum-by-the-number-value
        public override string ToString()
        {
            return $"ItemNumber: {this.ItemNumber}\n" +
                $"Brand: {this.Brand}\n" +
                $"Quantity: {this.Quantity}\n" +
                $"Wattage: {this.Wattage}\n" +
                $"Color: {this.Color}\n" +
                $"Price: {this.Price}\n" +
                $"Number of Doors: {DoorDescription(this.NumberOfDoors)}\n" +
                $"Height: {this.Height}\n" +
                $"Width: {this.Width}";
        }
    }
}
