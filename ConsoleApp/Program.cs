using Comparison;
using EF6;
using Linq2Sql;
using System;
using ORMFree;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var amount = 10000;

            var data = new MyData(amount);

            Console.WriteLine($"Using {amount} initial items");
            Console.WriteLine();

            var meterings = data.Meterings;

            Test.Run(new SQLClientProvider(meterings));

            Test.Run(new Linq2SqlProvider(meterings));

            Test.Run(new EF6Provider(meterings));


            Console.WriteLine("Finished. Hit Enter to continue..");
            Console.ReadLine();
        }
    }
}
