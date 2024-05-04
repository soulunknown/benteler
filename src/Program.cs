using System;
using System.Collections.Generic;

namespace SteelBilletInventory
{
    public class Billet
    {
        public int ID { get; set; }
        public double Weight { get; set; }
        public string Grade { get; set; }
        public string Dimensions { get; set; }

        public Billet(int id, double weight, string grade, string dimensions)
        {
            ID = id;
            Weight = weight;
            Grade = grade;
            Dimensions = dimensions;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Weight: {Weight}kg, Grade: {Grade}, Dimensions: {Dimensions}";
        }
    }

    public class InventoryManager
    {
        private List<Billet> billets = new List<Billet>();
        private int nextId = 1;  // Simulate an auto-incrementing primary key

        public void AddBillet(double weight, string grade, string dimensions)
        {
            billets.Add(new Billet(nextId++, weight, grade, dimensions));
            Console.WriteLine("Billet added successfully.");
        }

        public void RemoveBillet(int id)
        {
            var billet = billets.Find(b => b.ID == id);
            if (billet != null)
            {
                billets.Remove(billet);
                Console.WriteLine("Billet removed successfully.");
            }
            else
            {
                Console.WriteLine("Billet not found.");
            }
        }

        public void DisplayInventory()
        {
            if (billets.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            Console.WriteLine("Current Inventory:");
            foreach (var billet in billets)
            {
                Console.WriteLine(billet);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! Welcome to the Steel Billet Inventory System.");

            var manager = new InventoryManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1 - Add Billet");
                Console.WriteLine("2 - Remove Billet");
                Console.WriteLine("3 - Display Inventory");
                Console.WriteLine("4 - Exit");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter weight:");
                        double weight = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter grade:");
                        string grade = Console.ReadLine();
                        Console.WriteLine("Enter dimensions:");
                        string dimensions = Console.ReadLine();
                        manager.AddBillet(weight, grade, dimensions);
                        break;
                    case "2":
                        Console.WriteLine("Enter billet ID to remove:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        manager.RemoveBillet(id);
                        break;
                    case "3":
                        manager.DisplayInventory();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }
    }
}
