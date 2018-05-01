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
            }

            return sorted.ToArray();
        }
    }
}