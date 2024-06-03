using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 main St", "Cityville", "State", "12345");
        Lecture lecture1 = new Lecture("Python Workshop", "Learn Python Programming", "07-06-2024", "10:00 AM", address1, "Jacob Josh", 80);
        Console.WriteLine("----------------------------");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(lecture1.StandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(lecture1.FullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(lecture1.ShortDescription());

        Address address2 = new Address("56 Yonge St", "Toronto", "Canada", "54321");
        Reception receptionEvent = new Reception("Marriage Anniversary ", "10 Years Marriage Anniversary Celebration", "20-06-2024", "6:00 PM", address2, "info@weddinganniversary.com");
        Console.WriteLine("----------------------------");
        Console.WriteLine("\nStandard Details:");
        Console.WriteLine(receptionEvent.StandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(receptionEvent.FullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(receptionEvent.ShortDescription());

        Address address3 = new Address("246 Oak Circle", "London", "England", "67890");
        OutdoorGathering outdoorEvent = new OutdoorGathering("Summer BBQ", "Enjoy food and games", "01-07-2024", "12:00 PM", address3, "Sunny with a chance of rain");
        Console.WriteLine("----------------------------");
        Console.WriteLine("\nStandard Details:");
        Console.WriteLine(outdoorEvent.StandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(outdoorEvent.FullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(outdoorEvent.ShortDescription());
        Console.WriteLine("----------------------------");
      
    }
}