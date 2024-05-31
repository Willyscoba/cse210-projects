using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating Adresses.
        Address address1 = new Address("123 Main st", "New York City", "NY", "USA.");
        Address address2 = new Address("56 Yonge St", "Toronto", "CA", "Canada.");
        Address address3 = new Address("246 Oak Circle", "London", "England", "UK.");

        // Creating Constructors.
        Customer customer1 = new Customer("Jacob Josh", address1);
        Customer customer2 = new Customer("Vera Lacasa", address2);
        Customer customer3 = new Customer("John Terry", address3);

        // Creating products.
        Product product1 = new Product("Laptop", "1243LP", 1000, 2);
        Product product2 = new Product("Mouse", "57ME", 20, 5);
        Product product3 = new Product("Keyboard", "145KD", 50, 1);

        // Creating orders.
        Order order1 = new Order(customer1, new List<Product> { product1, product2 });
        Order order2 = new Order(customer2, new List<Product> { product2, product3 });
        Order order3 = new Order(customer3, new List<Product> { product3, product1 });

         // Displaying results
        Console.WriteLine("----------------------------");
        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\nOrder 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.Write("\nOrder 1 Total Price: ");
        Console.WriteLine("$" + order1.CalculateTotalCost());

        Console.WriteLine("----------------------------");
        Console.WriteLine("\nOrder 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\nOrder 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.Write("\nOrder 2 Total Price: ");
        Console.WriteLine("$" + order2.CalculateTotalCost());

        Console.WriteLine("----------------------------");
        Console.WriteLine("\nOrder 3 Packing Label:");
        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine("\nOrder 3 Shipping Label:");
        Console.WriteLine(order3.GetShippingLabel());
        Console.Write("\nOrder 3 Total Price: ");
        Console.WriteLine("$" + order3.CalculateTotalCost());
        Console.WriteLine("----------------------------");
    }
}