using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PrimeCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter as many numbers as you like(You can Enter numbers between {0} and {1})\nPress 'a' if you want to exit.", long.MinValue, long.MaxValue);
            while (true)
            {


                try
                {
                    var inp = Console.ReadLine();
                    if (inp.Equals("a"))
                    {
                        Console.WriteLine("Programm will finish when remaining camputations are done.");

                    }
                    var input = Convert.ToInt64(inp);
                    Thread checkPrime = new Thread(() => Program.IsPrime(input));
                    checkPrime.Start();
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The Number can't be stored in Long variable(Overflow)");
                }
                catch (FormatException)
                {
                    Console.WriteLine("You did not Enter a number!!\nPlease try again.");
                }


            }
        }

        public static bool IsPrime(long number)
        {
            if (number < 0)
            {
                Console.WriteLine("{0} is not Prime", number);
                return false;
            }
            if (number == 1)
            {
                Console.WriteLine("{0} is not Prime", number);
                return false;
            }
            if (number == 2)
            {
                Console.WriteLine("{0} is Prime", number);
                return true;
            }
            for (long i = 2; i <= Math.Floor(Math.Sqrt(number)); i += 2)
            {
                if (number % i == 0)
                {
                    Console.WriteLine("{0} is not Prime", number);
                    return false;
                }
                if (i == 2)
                    i--;
            }
            Console.WriteLine("{0} is Prime", number);
            return true;
        }
    }

}
