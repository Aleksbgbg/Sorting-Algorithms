namespace Sorting.Algorithms.Core.Sort
{
    using System.Collections.Generic;
    using System.Linq;

    using Sorting.Algorithms.Core.Interfaces;

    internal class InsertionSort<T> : ISortingAlgorithm<T>
    {
        public T[] Sort(IEnumerable<T> elements)
        {
            List<T> sorted = elements.ToList();

            for (int iteration = 0; iteration < sorted.Count; ++iteration)
            {
                for (int current = 0; current < sorted.Count; ++current)
                {
                    if (Comparer<T>.Default.Compare(sorted[iteration], sorted[current]) != -1) continue;

                    T temporary = sorted[iteration];
                    sorted[iteration] = sorted[current];
                    sorted[current] = temporary;
                }
            }

            return sorted.ToArray();
        }
    }
}