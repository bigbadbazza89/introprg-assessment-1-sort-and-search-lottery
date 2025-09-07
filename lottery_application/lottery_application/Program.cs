using System;

class Lottery
{
    static void Main()
        // This is the array to hold 5 chosen integers by the player
    {
        int[] chosen_numbers = new int[5];
        int count = 0;

        // Welcomes and asks for the lotto numbers from the player
        Console.WriteLine("Welcome to Big Bad Bazzas Lottery Bonanza!");
        Console.WriteLine("Please submit 5 numbers between 1 and 99");

        // This loop will continue until the player has entered 5 valid numbers
        while (count < 5)
        {
            Console.Write($"Enter number {count + 1}: ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int number) && number >= 1 && number <= 99)
            {
                chosen_numbers[count] = number;
                count++;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 99.");
            }
        }
        Random rnd = new Random();
        int[] randomNumber = new int[5];

        for (int i = 0; i < 5; i++)
        {
            randomNumber[i] = rnd.Next(1, 99);
        }
        
        Array.Sort(randomNumber);
        Array.Sort(chosen_numbers);

        Console.WriteLine("...And here are the winning numbers: ");
        foreach (int num in randomNumber)
        {
            Console.Write(num + " ");
        }

    }
}
