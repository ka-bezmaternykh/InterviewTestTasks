using System;

namespace FooBar.FooBarSimple
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from simple FooBar implementation.");
            Console.WriteLine("***");
            Console.WriteLine();

            FooBarSimple();

            Console.WriteLine();
            Console.WriteLine("***");
            Console.WriteLine("Work has finished. Have a nice day!");
            Console.WriteLine("Press any button to exit.");
            Console.ReadKey();
        }

        private static void FooBarSimple()
        {
            for (int i = 1; i <= 100; i++)
            {
                var msg = string.Empty;
                var devidedBy3 = i % 3 == 0;
                var devidedBy5 = i % 5 == 0;

                if (devidedBy3 && devidedBy5)
                {
                    msg = "FooBar";
                }
                else if (devidedBy3)
                {
                    msg = "Foo";
                }
                else if (devidedBy5)
                {
                    msg = "Bar";
                }
                else
                {
                    msg = i.ToString();
                }

                Console.WriteLine(msg);
            }
        }
    }
}
