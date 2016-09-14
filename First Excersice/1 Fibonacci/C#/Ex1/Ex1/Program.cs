using System;
namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fibonacci.Run(int.Parse(args[0])));
        }
    }

    public class Fibonacci
    {
        public static long Run(int n)
        {
            if (n == 1 || n == 2)
                return 1;
            return Run(n - 1) + Run(n - 2);
        }
    }
}
