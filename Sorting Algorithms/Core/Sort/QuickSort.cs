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

            Sort(array, 0, array.Length);

            return array;
        }

        private void Sort(T[] elements, int start, int end)
        {
            if (end - start < 2)
            {
                return;
            }

            int pivotIndex = end - 1;
            T pivot = elements[pivotIndex];

            for (int index = start; index < pivotIndex; ++index)
            {
                if (Comparer<T>.Default.Compare(elements[index], pivot) <= 0)
                {
                    continue;
                }

                for (int current = index; current < pivotIndex; ++current)
                {
                    elements.Swap(current, current + 1);
                }

                --pivotIndex;
                --index;
            }

            Sort(elements, start, pivotIndex);
            Sort(elements, pivotIndex + 1, end);
        }
    }
}