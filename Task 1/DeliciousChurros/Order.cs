using System;

namespace DeliciousChurros
{
    public class Order
    {
        public int OrderNo { get; set; }
        public string OrderDetails { get; set; }
        public int Quantity { get; set; }
        public double Bill { get; set; }

        public Order(int orderNo, string orderDetails, int quantity)
        {
            OrderNo = orderNo;
            OrderDetails = orderDetails;
            Quantity = quantity;
            Bill = 0;
        }

        public void PlaceOrder()
        {
            Console.WriteLine("\nOrder placed successfully.");
            Console.WriteLine($"Order Number: {OrderNo}");
            Console.WriteLine($"Order Details: {OrderDetails}");
            Console.WriteLine($"Quantity: {Quantity}");
        }

        public double PayBill(double price)
        {
            Bill = price * Quantity;
            return Bill;
        }

        public void CollectOrder()
        {
            Console.WriteLine($"Order No {OrderNo} has been collected.");
        }

        public void ShowOrder()
        {
            Console.WriteLine($"Order No: {OrderNo} | Item: {OrderDetails} | Quantity: {Quantity} | Bill: €{Bill:0.00}");
        }
    }
}