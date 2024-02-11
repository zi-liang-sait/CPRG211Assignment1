using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211Assignment1
{
    internal class Microwave(string number, string brand, int quantity, int wattage, string color, double price, double capacity, char roomType) : Appliance(number, brand, quantity, wattage, color, price)
    {
        public double Capacity { get; set; } = capacity;
        public char RoomType { get; set; } = roomType;

        private string RoomDescription(char roomType)
        {
            switch (roomType)
            {
                case 'K':
                    return "Kitchen";
                case 'W':
                    return "Work Site";
                default:
                    return "None";
            }
        }

        public override string FormatFile()
        {
            return $"{this.ItemNumber};{this.Brand};{this.Quantity};{this.Wattage};{this.Color};{this.Price};{this.Capacity};{this.RoomType};";
        }

        public override string ToString()
        {
            return $"ItemNumber: {this.ItemNumber}\n" +
                $"Brand: {this.Brand}\n" +
                $"Quantity: {this.Quantity}\n" +
                $"Wattage: {this.Wattage}\n" +
                $"Color: {this.Color}\n" +
                $"Price: {this.Price}\n" +
                $"Capacity: {this.Capacity}\n" +
                $"Room Type: {RoomDescription(this.RoomType)}";
        }
    }
}
