using System;

class Program
{
    static void Main(string[] args)
    {
        // ORDER 1 - Customer in the USA
        Address address1 = new Address(
            "123 Main Street",
            "Salt Lake City",
            "Utah",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        Product product1 = new Product(
            "C# Programming Book",
            "P100",
            25.00,
            2
        );

        Product product2 = new Product(
            "Wireless Mouse",
            "P200",
            15.00,
            1
        );

        Product product3 = new Product(
            "Keyboard",
            "P300",
            30.00,
            1
        );

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        // ORDER 2 - Customer outside the USA
        Address address2 = new Address(
            "15 Taufa'ahau Road",
            "Nuku'alofa",
            "Tongatapu",
            "Tonga"
        );

        Customer customer2 = new Customer(
            "Talasinga Tonga",
            address2
        );

        Product product4 = new Product(
            "Laptop Bag",
            "P400",
            40.00,
            1
        );

        Product product5 = new Product(
            "USB Cable",
            "P500",
            10.00,
            3
        );

        Product product6 = new Product(
            "Headphones",
            "P600",
            35.00,
            1
        );

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);


        // Display Order 1
        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 1");
        Console.WriteLine("========================================");
        Console.WriteLine();

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}");

        Console.WriteLine();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine();

        // Display Order 2
        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 2");
        Console.WriteLine("========================================");
        Console.WriteLine();

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():0.00}");
    }
}