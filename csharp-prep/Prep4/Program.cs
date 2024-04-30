using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        while (true)
        {
            Console.Write("Enter a list of numbers, (enter 0 to quit): ");
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
                break;
            
            numbers.Add(number);
            
        }
        Console.WriteLine("Number entered:");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine("The Sum is: " + sum);

        float average = (float)sum / numbers.Count;
        Console.WriteLine("The average is: " + average);

        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine("The Max is: " + max);

        int minPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < minPositive)
            {
                minPositive = number;
            }
        }
        if (minPositive == int.MaxValue)
        {
            Console.WriteLine("No positive numbers entered.");
        }
        else
        {
            Console.WriteLine("The smallest positive number is: " + minPositive);
        }

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}