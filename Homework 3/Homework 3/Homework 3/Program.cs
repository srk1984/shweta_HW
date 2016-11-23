//Program to compute factorial from 1 to n

class polynomial
{
    static void Main()
    {
        string str;

        int n, i, fact = 1,k = 0;

        //Assigned fact=1
        //i and k indexes

        //Take an integer as input

        Console.Write("Enter a small positive integer jjjj : ");

        str = Console.ReadLine();

        //Parse the input to get an integer

        n = int.Parse(str);

        //Calculation of factorial
        Console.WriteLine("value of k :{0}", k);

        for (i = 1; i<=n; i++,k++)
        {
            fact *= i;


            Console.WriteLine("Factorial of {0}! = {1}", k, fact);
        }

        Console.ReadLine();
    }

}
