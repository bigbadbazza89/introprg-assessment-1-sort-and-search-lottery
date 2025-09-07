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
    }
}
