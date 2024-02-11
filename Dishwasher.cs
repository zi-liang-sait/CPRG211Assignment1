using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211Assignment1
{
    internal class Dishwasher(string number, string brand, int quantity, int wattage, string color, double price, string feature, string soundRating) : Appliance(number, brand, quantity, wattage, color, price)
    {
        public string Feature { get; set; } = feature;
        public string SoundRating { get; set; } = soundRating;

        private string SoundRatingDescription(string rating)
        {
            switch (rating)
            {
                case "Qt":
                    return "Quietest";
                case "Qr":
                    return "Quieter";
                case "Qu":
                    return "Quiet";
                case "M":
                    return "Moderate";
                default:
                    return "None";
            }
        }

        public override string FormatFile()
        {
            return $"{this.ItemNumber};{this.Brand};{this.Quantity};{this.Wattage};{this.Color};{this.Price};{this.Feature};{this.SoundRating};";
        }

        public override string ToString()
        {
            return $"ItemNumber: {this.ItemNumber}\n" +
                $"Brand: {this.Brand}\n" +
                $"Quantity: {this.Quantity}\n" +
                $"Wattage: {this.Wattage}\n" +
                $"Color: {this.Color}\n" +
                $"Price: {this.Price}\n" +
                $"Feature: {this.Feature}\n" +
                $"SoundRating: {SoundRatingDescription(this.SoundRating)}";
        }
    }
}
