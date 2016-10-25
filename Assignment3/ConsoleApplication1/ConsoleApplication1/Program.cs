using System;

class polynomial
{
    static void Main()
    {
        string str;

        int x, i, fact = 1;

        //Assigned fact=1
        //Take an integer as input

        Console.Write("Enter a small positive integer : ");

        str = Console.ReadLine();

        //Parse the input to get an integer

        x = int.Parse(str);

        //Calculation of factorial

        for (i = x; i > 0; i--)
        {
            fact *= i;
        }

        Console.WriteLine("Factorial of {0}! = {1}", x, fact);

        Console.ReadLine();
    }

}
