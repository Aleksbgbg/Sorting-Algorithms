namespace Sorting.Algorithms.Core.Sort
{
    using System.Collections.Generic;
    using System.Linq;

    using Sorting.Algorithms.Core.Extensions;
    using Sorting.Algorithms.Core.Logging;

    internal class InsertionSort<T> : ISortingAlgorithm<T>
    {
        public T[] Sort(IEnumerable<T> elements)
        {
            Logger.Default.Log(LogLevel.Info, "Initiating Insertion sort");

            T[] array = elements.ToArray();

            Logger.Default.Log(LogLevel.Info, $"Initial array: {array.JoinWithSpace()}");

            for (int subjectIndex = 1; subjectIndex < array.Length; ++subjectIndex)
            {
                T subject = array[subjectIndex];

                for (int insertionIndex = subjectIndex - 1; ; --insertionIndex)
                {
                    if (insertionIndex >= 0 && Comparer<T>.Default.Compare(array[insertionIndex], subject) >= 0)
                    {
                        continue;
                    }

                    array.ShiftElement(subjectIndex, insertionIndex + 1);

                    break;
                }

                Logger.Default.Log(LogLevel.Debug, $"Pass {subjectIndex}: {array.JoinWithSpace()}");
            }

            Logger.Default.Log(LogLevel.Info, $"Final array: {array.JoinWithSpace()}");

            return array;
        }
    }
}