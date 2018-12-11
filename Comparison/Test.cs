using System;
using System.Diagnostics;

namespace Comparison
{
    public static class Test
    {
        public static void Run(IProvider provider)
        {
            Console.WriteLine($"Testing { provider.Name } provider");

            provider.ClearSource();
            Console.WriteLine($" * Non-parallel iterative insertion: " +
                $"{ElapsedTime(provider.NonParallelIterativeInsertion)} ms");

            provider.ClearSource();
            Console.WriteLine($" * Parallel iterative insertion: " +
                $"{ElapsedTime(provider.ParallelIterativeInsertion)} ms");

            provider.ClearSource();
            Console.WriteLine($" * Bulk insertion: " +
                $"{ElapsedTime(provider.BulkInsertion)} ms");

            provider.ClearSource();

            Console.WriteLine();
        }

        private static long ElapsedTime(params Action[] actions)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var action in actions) action();

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

    }
}
