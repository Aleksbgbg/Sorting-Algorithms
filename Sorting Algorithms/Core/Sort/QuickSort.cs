namespace Sorting.Algorithms.Core.Sort
{
    using System.Collections.Generic;
    using System.Linq;

    using Sorting.Algorithms.Core.Interfaces;
    using Sorting.Algorithms.Core.Logging;

    internal class QuickSort<T> : ISortingAlgorithm<T>
    {
        public T[] Sort(IEnumerable<T> elements)
        {
            Logger.Default.Log(LogLevel.Info, "Initiating Quick sort");

            T[] array = elements.ToArray();

            Logger.Default.Log(LogLevel.Info, $"Initial array: {array.JoinWithSpace()}");

            Sort(array, 0, array.Length);

            Logger.Default.Log(LogLevel.Info, $"Final array: {array.JoinWithSpace()}");

            return array;
        }

        private void Sort(T[] array, int start, int end)
        {
            while (true)
            {
                if (end - start < 2)
                {
                    return;
                }

                int pivotIndex = end - 1;
                T pivot = array[pivotIndex];

                for (int index = start; index < pivotIndex; ++index)
                {
                    if (Comparer<T>.Default.Compare(array[index], pivot) <= 0)
                    {
                        continue;
                    }

                    for (int current = index; current < pivotIndex; ++current)
                    {
                        array.Swap(current, current + 1);
                    }

                    --pivotIndex;
                    --index;
                }

                Sort(array, start, pivotIndex);

                start = pivotIndex + 1;
            }
        }
    }
}