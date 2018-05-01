namespace Sorting.Algorithms.Core.Sort
{
    using System.Collections.Generic;
    using System.Linq;

    using Sorting.Algorithms.Core.Interfaces;

    internal class BubbleSort<T> : ISortingAlgorithm<T>
    {
        public T[] Sort(IEnumerable<T> elements)
        {
            T[] array = elements.ToArray();

            for (int iteration = 1; iteration <= array.Length; ++iteration)
            {
                bool movedElement = false;

                for (int index = 0; index < array.Length - iteration; ++index)
                {
                    T current = array[index];
                    T next = array[index + 1];

                    if (Comparer<T>.Default.Compare(current, next) < 1)
                    {
                        continue;
                    }

                    array[index + 1] = current;
                    array[index] = next;

                    movedElement = true;
                }

                if (!movedElement)
                {
                    break;
                }
            }

            return array;
        }
    }
}