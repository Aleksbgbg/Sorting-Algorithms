namespace Sorting.Algorithms.Core.Sort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sorting.Algorithms.Core.Interfaces;
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
            T[] array = elements.ToArray();

            if (array is int[] intArray)
            {
                Sort(intArray);
            }

            return array;
        }

        private int[] Sort(int[] array)
        {
            int maxValue = array.Max();

            for (int iteration = 0; (int)Math.Pow(_base, iteration) <= maxValue; ++iteration)
            {
                Logger.Default.Log(LogLevel.Debug, array.JoinWithSpace());
                array = GetArray(GetBuckets(array, iteration));
            }

            Logger.Default.Log(LogLevel.Info, $"Final array: {array.JoinWithSpace()}");

            return array;
        }

        private List<int>[] GetBuckets(int[] array, int digitIndex)
        {
            List<int>[] buckets = new List<int>[_base];

            for (int index = 0; index < buckets.Length; ++index)
            {
                buckets[index] = new List<int>();
            }

            foreach (int element in array)
            {
                int bucketIndex = element / (int)Math.Pow(_base, digitIndex) % _base;

                Logger.Default.Log(LogLevel.Debug, $"{element} : {bucketIndex}");

                buckets[bucketIndex].Add(element);
            }

            Logger.Default.Log(LogLevel.Debug, $"Buckets: {buckets.Select(x => x.JoinWithSpace()).Join(" | ")}");

            return buckets;
        }

        private int[] GetArray(List<int>[] buckets)
        {
            int[] array = new int[buckets.Sum(list => list.Count)];

            int currentIndex = 0;

            foreach (List<int> bucket in buckets)
            {
                bucket.CopyTo(array, currentIndex);
                currentIndex += bucket.Count;
            }

            return array;
        }
    }
}