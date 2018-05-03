namespace Sorting.Algorithms.Core.Sort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sorting.Algorithms.Core.Extensions;
    using Sorting.Algorithms.Core.Logging;

    internal class RadixSortLsd<T> : ISortingAlgorithm<T>
    {
        private readonly int _base;

        internal RadixSortLsd(int radix = 10)
        {
            _base = radix;
        }

        public T[] Sort(IEnumerable<T> elements)
        {
            Logger.Default.Log(LogLevel.Info, "Initiating Radix sort (LSD)");

            T[] array = elements.ToArray();

            Logger.Default.Log(LogLevel.Info, $"Initial array: {array.JoinWithSpace()}");

            if (array is int[] intArray)
            {
                Sort(intArray);
            }

            Logger.Default.Log(LogLevel.Info, $"Final array: {array.JoinWithSpace()}");

            return array;
        }

        private void Sort(int[] array)
        {
            List<int>[] buckets = new List<int>[_base];

            for (int index = 0; index < buckets.Length; ++index)
            {
                buckets[index] = new List<int>();
            }

            int maxValue = array.Max();

            int placeValue;

            for (int iteration = 0; (placeValue = (int)Math.Pow(_base, iteration)) <= maxValue; ++iteration)
            {
                foreach (int element in array)
                {
                    buckets[element / placeValue % _base].Add(element);
                }

                Logger.Default.Log(LogLevel.Debug, $"Buckets: {buckets.Select(bucket => bucket.JoinWithSpace()).Join(" | ")}");

                int arrayCopyIndex = 0;

                foreach (List<int> bucket in buckets)
                {
                    bucket.CopyTo(array, arrayCopyIndex);
                    arrayCopyIndex += bucket.Count;
                    bucket.Clear();
                }

                Logger.Default.Log(LogLevel.Debug, $"Pass {iteration + 1}: {array.JoinWithSpace()}");
            }
        }
    }
}