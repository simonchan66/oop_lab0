using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System.Numerics;

class Program
{
    public static bool IsPrime(int n)
    {
        for (int denominator = n - 1; denominator > 1; denominator--)
        {
            int remainder = n % denominator;

            if (remainder == 0)
                return false;
        }

        return true;
    }

    public static void printPrimes(int low, int high)
    {
        for (int i = low+1; i < high; i++)
        {
            if (IsPrime(i))
            {
                Console.WriteLine(i + " is a Prime number.");
            }
        }
    }
    static void Main()
    {
        string fileName = "numbers.txt";

            FileStream fs = File.Create(fileName);

            fs.Close();


        int lownumber;
        do
        {
            Console.Write("Please enter a low number: ");
            string lownumber_input = Console.ReadLine();
            lownumber = int.Parse(lownumber_input);
        } while (lownumber <= 0);


        int highnumber;
        do
        {
            Console.Write("Please enter a high number: ");
            string highnumber_input = Console.ReadLine();
            highnumber = int.Parse(highnumber_input);

        } while (highnumber <= lownumber);


        int difference = highnumber - lownumber;

        Console.WriteLine("The difference is " + difference);

        int[] everynumber = new int[difference -1];
        for (int i = 0; i < everynumber.Length; i++)
        {
            everynumber[i] = lownumber + i +1 ;
        }
        Array.Reverse(everynumber);


        using (StreamWriter outputFile = new StreamWriter("numbers.txt"))
        {

            foreach (int i in everynumber)
            {
                outputFile.WriteLine(i);
            }

        }
        int[] allNumbers = File.ReadAllLines(fileName).Select(line => int.Parse(line)).ToArray();
        int sum = allNumbers.Sum();
        Console.WriteLine($"The sum of the numbers is {sum}");

        printPrimes(lownumber, highnumber);
    }
}

