using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211Assignment1
{
    internal class Vacuum(string number, string brand, int quantity, int wattage, string color, double price, string grade, int batteryVoltage) : Appliance(number, brand, quantity, wattage, color, price)
    {
        public string? Grade { get; set; } = grade;
        public int BatteryVoltage { get; set; } = batteryVoltage;

        private string VoltageDescription(int voltage)
        {
            switch (voltage)
            {
                case 18:
                    return "Low";
                case 24:
                    return "High";
                default:
                    return "Unknown";
            }
        }

        public override string FormatFile()
        {
            return $"{this.ItemNumber};{this.Brand};{this.Quantity};{this.Wattage};{this.Color};{this.Price};{this.Grade};{this.BatteryVoltage};";
        }

        public override string ToString()
        {
            return $"ItemNumber: {this.ItemNumber}\n" +
                $"Brand: {this.Brand}\n" +
                $"Quantity: {this.Quantity}\n" +
                $"Wattage: {this.Wattage}\n" +
                $"Color: {this.Color}\n" +
                $"Price: {this.Price}\n" +
                $"Grade: {this.Grade}\n" +
                $"Battery Voltage: {VoltageDescription(this.BatteryVoltage)}";
        }
    }
}
