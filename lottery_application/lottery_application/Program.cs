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
                bool alreadyChosen = false;
                for (int i = 0; i < count; i++)
                {
                    if (chosen_numbers[i] == number)
                    {
                        alreadyChosen = true;
                        break;
                    }
                }

                if (alreadyChosen)
                {
                    Console.WriteLine("You've already chosen that number. Pick a different one.");
                }
                else
                {
                    chosen_numbers[count] = number;
                    count++;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 99.");
            }
        }
        Random rnd = new Random();
        int[] random_numbers = new int[5];

        for (int i = 0; i < 5; i++)
        {
            random_numbers[i] = rnd.Next(1, 99);
        }

        Array.Sort(random_numbers);
        Array.Sort(chosen_numbers);

        Console.WriteLine("\n\n...And here are the winning numbers: ");
        foreach (int num in random_numbers)
        {
            Console.Write(num + " ");
        }

        Console.WriteLine("\n\nChecking to see if you have any matches...");
        bool found_match = false;

        foreach (int num in chosen_numbers)
        {
            int index = LinearSearch(random_numbers, num);
            if (index != -1)
            {
                Console.WriteLine($"{num} is a winner! You win the prize!");
                found_match = true;
            }
        }

        if (!found_match)
        {
            Console.WriteLine("Unlucky mate. Better luck next time");
        }


        Console.WriteLine("\n\nAnd just to confirm...");
        bool confirm_match = false;

        foreach (int num in chosen_numbers)
        {
            int index = BinarySearch(random_numbers, num, 0, random_numbers.Length - 1);
            if (index != -1)
            {
                Console.WriteLine($"{num} is a winner! You DEFINITELY win the prize!");
                confirm_match = true;
            }
        }

        if (!confirm_match)
        {
            Console.WriteLine("TRULY Unlucky mate. Better luck next time");
        }
    }

    static int LinearSearch(int[] array, int value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return i;
            }
        }
        return -1;
    }

    static int BinarySearch(int[] array, int value, int low, int high)
    {
        if (high >= low)
        {
            int mid = (high + low) / 2;

            if (array[mid] == value) return mid;

            if (array[mid] > value) return BinarySearch(array, value, low, mid - 1);

            return BinarySearch(array, value, mid + 1, high);


        }
        return -1;

    }
}
