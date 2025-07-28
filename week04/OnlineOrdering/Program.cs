using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - USA
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "N123", 3.50m, 4));
        order1.AddProduct(new Product("Pen Set", "P456", 5.00m, 2));

        // Order 2 - International
        Address address2 = new Address("456 Park Lane", "London", "Greater London", "UK");
        Customer customer2 = new Customer("James Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Planner", "PL789", 10.00m, 1));
        order2.AddProduct(new Product("Markers", "M321", 2.00m, 5));
        order2.AddProduct(new Product("Folder", "F654", 1.25m, 3));

        // Display Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}");
        Console.WriteLine(new string('-', 40));

        // Display Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
        Console.WriteLine(new string('-', 40));
    }
}
