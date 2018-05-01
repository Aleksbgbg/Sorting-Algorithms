namespace Sorting.Algorithms.Core.Sort
{
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

            foreach (T element in array)
            {
                int comparison = Comparer<T>.Default.Compare(element, pivot);

                if (comparison == -1)
                {
                    left.Add(element);
                }
                else if (comparison == 1)
                {
                    right.Add(element);
                }
            }

            return Sort(left).Append(pivot).Union(Sort(right)).ToArray();
        }
    }
}