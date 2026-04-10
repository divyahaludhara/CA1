using System;
using System.Collections.Generic;

namespace DeliciousChurros
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<Order> orderQueue = new Queue<Order>();
            int orderCounter = 1;
            int choice;

            Churros c1 = new Churros("Churros with plain sugar", 6.00);
            Churros c2 = new Churros("Churros with cinnamon sugar", 6.00);
            Churros c3 = new Churros("Churros with chocolate sauce", 8.00);
            Churros c4 = new Churros("Churros with Nutella", 8.00);

            do
            {
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine("Delicious Churros:");
                Console.WriteLine("1. Place order");
                Console.WriteLine("2. Deliver order");
                Console.WriteLine("0. Exit");
                Console.WriteLine("-----------------------------------");
                Console.Write("Choose your option: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter 0, 1 or 2.");
                    continue;
                }

                if (choice == 1)
                {
                    Console.WriteLine("\nMenu:");
                    Console.WriteLine("1. Churros with plain sugar: €6.00");
                    Console.WriteLine("2. Churros with cinnamon sugar: €6.00");
                    Console.WriteLine("3. Churros with chocolate sauce: €8.00");
                    Console.WriteLine("4. Churros with Nutella: €8.00");

                    Console.Write("Select churros type: ");
                    if (!int.TryParse(Console.ReadLine(), out int itemChoice))
                    {
                        Console.WriteLine("Invalid choice.");
                        continue;
                    }

                    Console.Write("Enter quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
                    {
                        Console.WriteLine("Invalid quantity.");
                        continue;
                    }

                    string selectedItem = "";
                    double selectedPrice = 0;

                    if (itemChoice == 1)
                    {
                        selectedItem = c1.ChurrosType;
                        selectedPrice = c1.Price;
                    }
                    else if (itemChoice == 2)
                    {
                        selectedItem = c2.ChurrosType;
                        selectedPrice = c2.Price;
                    }
                    else if (itemChoice == 3)
                    {
                        selectedItem = c3.ChurrosType;
                        selectedPrice = c3.Price;
                    }
                    else if (itemChoice == 4)
                    {
                        selectedItem = c4.ChurrosType;
                        selectedPrice = c4.Price;
                    }
                    else
                    {
                        Console.WriteLine("Invalid churros choice.");
                        continue;
                    }

                    Order order = new Order(orderCounter, selectedItem, qty);
                    order.PlaceOrder();

                    double totalBill = order.PayBill(selectedPrice);
                    Console.WriteLine($"Total Bill: €{totalBill:0.00}");

                    orderQueue.Enqueue(order);
                    Console.WriteLine("Payment received. Order added to queue.");

                    orderCounter++;
                }
                else if (choice == 2)
                {
                    if (orderQueue.Count > 0)
                    {
                        Order deliveredOrder = orderQueue.Dequeue();
                        Console.WriteLine("\nDelivering order...");
                        deliveredOrder.ShowOrder();
                        deliveredOrder.CollectOrder();
                    }
                    else
                    {
                        Console.WriteLine("No orders in queue.");
                    }
                }
                else if (choice == 0)
                {
                    Console.WriteLine("Exiting system. Thank you.");
                }
                else
                {
                    Console.WriteLine("Invalid menu choice.");
                }

            } while (choice != 0);
        }
    }
}