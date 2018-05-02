namespace Sorting.Algorithms
{
    using System;

    using Sorting.Algorithms.Core.Interfaces;
    using Sorting.Algorithms.Core.Logging;
    using Sorting.Algorithms.Core.Sort;

    internal static class Program
    {
        private static void Main()
        {
            int[] numbers = GenerateNumbers();

            foreach (ISortingAlgorithm<int> algorithm in new ISortingAlgorithm<int>[]
            {
                    new BubbleSort<int>(),
                    new InsertionSort<int>(),
                    new QuickSort<int>(),
                    new RadixSortLsd<int>()
            })
            {
                algorithm.Sort(numbers);
                Logger.Default.Log(LogLevel.Info, string.Empty);
            }

            Logger.Default.Flush(LogLevel.Debug);
        }

        private static int[] GenerateNumbers(int count = 10, int range = 100)
        {
            Random random = new Random();

            int[] numbers = new int[count];

            for (int index = 0; index < numbers.Length; ++index)
            {
                numbers[index] = random.Next(range);
            }

            return numbers;
        }
    }
}