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

            List<T> sorted = elements.ToList();

            Logger.Default.Log(LogLevel.Info, $"Initial array: {sorted.JoinWithSpace()}");

            for (int subjectIndex = 1; subjectIndex < sorted.Count; ++subjectIndex)
            {
                T subject = sorted[subjectIndex];

                for (int insertionIndex = subjectIndex - 1; ; --insertionIndex)
                {
                    if (insertionIndex >= 0 && Comparer<T>.Default.Compare(sorted[insertionIndex], subject) > -1)
                    {
                        continue;
                    }

                    sorted.RemoveAt(subjectIndex);
                    sorted.Insert(insertionIndex + 1, subject);

                    break;
                }

                Logger.Default.Log(LogLevel.Debug, $"Pass {subjectIndex}: {sorted.JoinWithSpace()}");
            }

            Logger.Default.Log(LogLevel.Info, $"Final array: {sorted.JoinWithSpace()}");

            return sorted.ToArray();
        }
    }
}