namespace Sorting.Algorithms.Core.Sort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sorting.Algorithms.Core.Interfaces;

    internal class QuickSort<T> : ISortingAlgorithm<T>
    {
        public T[] Sort(IEnumerable<T> elements)
        {
            T[] array = elements.ToArray();

            if (array.Length < 2)
            {
                return array;
            }

            T pivot = array.Last();

            List<T> left = new List<T>();
            List<T> right = new List<T>();

            for (int index = 0; index < array.Length - 1; ++index)
            {
                T element = array[index];

                if (Comparer<T>.Default.Compare(element, pivot) == -1)
                {
                    left.Add(element);
                    continue;
                }

                right.Add(element);
            }

            T[] sortedLeft = Sort(left);
            T[] sortedRight = Sort(right);

            sortedLeft.CopyTo(array, 0);
            array[sortedLeft.Length] = pivot;
            sortedRight.CopyTo(array, sortedLeft.Length + 1);

            return array;
        }
    }
}