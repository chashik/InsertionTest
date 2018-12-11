using System;

namespace NetCoreTest
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

            Test.Run(new EFCProvider(meterings));

            Console.WriteLine("Finished. Hit Enter to continue..");
            Console.ReadLine();
        }
    }
}
