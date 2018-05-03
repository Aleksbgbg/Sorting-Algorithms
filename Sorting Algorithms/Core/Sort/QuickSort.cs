namespace Sorting.Algorithms.Core.Sort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sorting.Algorithms.Core.Extensions;
    using Sorting.Algorithms.Core.Logging;

    internal class QuickSort<T> : ISortingAlgorithm<T>
    {
        private readonly Func<int, int, int> _pivotIndexPicker;

        internal QuickSort() : this((start, end) => end - 1)
        {
        }

        internal QuickSort(Func<int, int, int> pivotIndexPicker)
        {
            _pivotIndexPicker = pivotIndexPicker;
        }

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

                int pivotIndex = _pivotIndexPicker(start, end);
                T pivot = array[pivotIndex];

                bool pivotIsLast = pivotIndex == end - 1;

                // Scan elements below pivot, and if they are bigger than the pivot, move them above the pivot
                for (int index = start; index < pivotIndex; ++index)
                {
                    if (Comparer<T>.Default.Compare(array[index], pivot) <= 0)
                    {
                        continue;
                    }

                    array.ShiftElement(index, pivotIndex);

                    --pivotIndex;
                    --index;
                }

                if (!pivotIsLast) // Unnecessary when the pivot is last, as only elements bigger than the pivot would have been shifted above
                {
                    // Scan elements above pivot, and if they are smaller than the pivot, move them below the pivot
                    for (int index = pivotIndex + 1; index < end; ++index)
                    {
                        if (Comparer<T>.Default.Compare(array[index], pivot) >= 0)
                        {
                            continue;
                        }

                        array.ShiftElement(index, pivotIndex);

                        ++pivotIndex;
                    }
                }

                Sort(array, start, pivotIndex);

                start = pivotIndex + 1;
            }
        }
    }
}