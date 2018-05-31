namespace Sorting.Algorithms
{
    using System;
    using System.Diagnostics;

    using Sorting.Algorithms.Core;
    using Sorting.Algorithms.Core.Extensions;
    using Sorting.Algorithms.Core.Logging;
    using Sorting.Algorithms.Core.Sort;

    using static System.Console;

    internal static class Program
    {
        private static readonly Random Random = new Random();

        private static void Main()
        {
            WriteLine(new QuickSort<int>().Sort(new int[] { }).JoinWithSpace());
        }

        private static void PerformSorts<T>(T[] data)
        {
            foreach (ISortingAlgorithm<T> algorithm in new ISortingAlgorithm<T>[]
            {
                    new BubbleSort<T>(),
                    new InsertionSort<T>(),
                    new QuickSort<T>((start, end) => Random.Next(start, end)),
                    new RadixSortLsd<T>()
            })
            {
                algorithm.Sort(data);
                Logger.Default.Log(LogLevel.Info, string.Empty);
            }

            Logger.Default.Flush(LogLevel.Trace);
        }

        private static void Profile(ISortingAlgorithm<int> sortingAlgorithm)
        {
            Logger.Default.Log(LogLevel.Debug, $"Profiling {sortingAlgorithm.GetType().Name}");

            int[] numbers = GenerateNumbers();

            Stopwatch stopwatch = Stopwatch.StartNew();

            sortingAlgorithm.Sort(numbers);

            stopwatch.Stop();

            Logger.Default.Log(LogLevel.Trace, $"Results: {stopwatch.ElapsedTicks} ticks; {stopwatch.ElapsedMilliseconds} ms ({stopwatch.Elapsed:T})");
        }

        private static int[] GenerateNumbers(int count = 10, int range = 100)
        {
            int[] numbers = new int[count];

            for (int index = 0; index < numbers.Length; ++index)
            {
                numbers[index] = Random.Next(range);
            }

            return numbers;
        }
    }
}