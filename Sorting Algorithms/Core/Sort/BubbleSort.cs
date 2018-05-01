namespace Sorting.Algorithms.Core.Sort
{
    using System.Collections.Generic;
    using System.Linq;

    using Sorting.Algorithms.Core.Interfaces;
    using Sorting.Algorithms.Core.Logging;

    internal class BubbleSort<T> : ISortingAlgorithm<T>
    {
        public T[] Sort(IEnumerable<T> elements)
        {
            Logger.Default.Log(LogLevel.Info, "Initiating Bubble sort");

            T[] array = elements.ToArray();

            Logger.Default.Log(LogLevel.Info, $"Initial array: {string.Join(" ", array)}");

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

                Logger.Default.Log(LogLevel.Debug, $"Pass {iteration}: {string.Join(" ", array)}");

                if (!movedElement)
                {
                    break;
                }
            }

            Logger.Default.Log(LogLevel.Info, $"Final array: {string.Join(" ", array)}");

            return array;
        }
    }
}