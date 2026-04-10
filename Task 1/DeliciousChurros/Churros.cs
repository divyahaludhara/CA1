using System;

namespace DeliciousChurros
{
    public class Churros
    {
        public string ChurrosType { get; set; }
        public double Price { get; set; }

        public Churros(string churrosType, double price)
        {
            ChurrosType = churrosType;
            Price = price;
        }

        public void ShowItem()
        {
            Console.WriteLine($"{ChurrosType}: €{Price:0.00}");
        }
    }
}