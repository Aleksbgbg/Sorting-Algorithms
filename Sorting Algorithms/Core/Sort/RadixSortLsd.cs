namespace Sorting.Algorithms.Core.Sort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sorting.Algorithms.Core.Interfaces;
    using Sorting.Algorithms.Core.Logging;

    internal class RadixSortLsd<T> : ISortingAlgorithm<T>
    {
        private const int Base = 10;

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
            List<int>[] GetBuckets(int[] elements, int digitIndex)
            {
                List<int>[] buckets = new List<int>[Base];

                for (int index = 0; index < buckets.Length; ++index)
                {
                    buckets[index] = new List<int>();
                }

                foreach (int element in elements)
                {
                    int bucketIndex = element / (int)Math.Pow(Base, digitIndex) % Base;

                    Logger.Default.Log(LogLevel.Debug, $"{element} : {bucketIndex}");

                    buckets[bucketIndex].Add(element);
                }

                Logger.Default.Log(LogLevel.Debug, $"Buckets: {buckets.Select(x => x.JoinWithSpace()).Join(" | ")}");

                return buckets;
            }

            int[] GetArray(List<int>[] buckets)
            {
                int[] arrayReturn = new int[buckets.Sum(list => list.Count)];

                int currentIndex = 0;

                foreach (List<int> bucket in buckets)
                {
                    bucket.CopyTo(arrayReturn, currentIndex);
                    currentIndex += bucket.Count;
                }

                return arrayReturn;
            }

            int maxValue = array.Max();

            for (int iteration = 0; (int)Math.Pow(Base, iteration) <= maxValue; ++iteration)
            {
                Logger.Default.Log(LogLevel.Debug, array.JoinWithSpace());
                array = GetArray(GetBuckets(array, iteration));
            }

            Logger.Default.Log(LogLevel.Info, $"Final array: {array.JoinWithSpace()}");

            return array;
        }
    }
}