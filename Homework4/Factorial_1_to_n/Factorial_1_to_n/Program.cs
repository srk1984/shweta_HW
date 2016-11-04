using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//program to find factorial of 1 to n

namespace Factorial_1_to_n
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=0,i=0,fact=1,k=1;
            //n- number of factoials to be displayed
            //fact - to store factorial
            //i and k for looping
      
            Console.Write("Enter a small positive integer : ");

            string str = Console.ReadLine();

            n = int.Parse(str); 
             
            if (n==0)
             {
               Console.WriteLine("Factorial of 0 : {0}", fact);
             }

           for (i = 1; i <= n; i++,k++)
            {
                fact *= i;

                Console.WriteLine("Factorial of {0} = {1}", k , fact);
              
            }

            Console.ReadLine();
          }

        
    }
}
