using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        //Note: You can't run both codes together, put first and second part in a comment mode, before running the 3rd part
        //also, put the 3rd part in a comment mode before running the first part.
        //For the first and second part where the user have to provide the magic number...
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        while (true)
        {
            Console.Write("What is your guess? ");
            int guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess >magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                break;
            }
        }

        //for the 3rd part.
        
        Random randomGenerator = new Random();
        string playAgain;
        {
            int magicNumber = randomGenerator.Next(1, 101);
            int Guesses = 0;

            while (true)
            {
                Console.Write("What is your guess? ");
                int guess = int.Parse(Console.ReadLine());
                Guesses++;

                if (magicNumber > guess)
                {
                Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    break;
                }
            }
            Console.WriteLine("Number of guesses: " + Guesses);
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();
        } while (playAgain == "yes");
    
        Console.WriteLine("Thanks for playing!");
        
    }
}
