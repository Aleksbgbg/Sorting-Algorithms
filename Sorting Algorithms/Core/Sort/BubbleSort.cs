namespace Sorting.Algorithms.Core.Sort
{
    using System.Collections.Generic;
    using System.Linq;

    using Sorting.Algorithms.Core.Extensions;
    using Sorting.Algorithms.Core.Logging;

    internal class BubbleSort<T> : ISortingAlgorithm<T>
    {
        public T[] Sort(IEnumerable<T> elements)
        {
            Logger.Default.Log(LogLevel.Info, "Initiating Bubble sort");

            T[] array = elements.ToArray();

            Logger.Default.Log(LogLevel.Info, $"Initial array: {array.JoinWithSpace()}");

            for (int iteration = 1; iteration <= array.Length; ++iteration)
            {
                bool movedElement = false;

                for (int index = 0; index < array.Length - iteration; ++index)
                {
                    if (Comparer<T>.Default.Compare(array[index], array[index + 1]) <= 0)
                    {
                        continue;
                    }

                    array.Swap(index, index + 1);

                    movedElement = true;
                }

                Logger.Default.Log(LogLevel.Debug, $"Pass {iteration}: {array.JoinWithSpace()}");

                if (!movedElement)
                {
                    break;
                }
            }

            Logger.Default.Log(LogLevel.Info, $"Final array: {array.JoinWithSpace()}");

            return array;
        }
    }
}