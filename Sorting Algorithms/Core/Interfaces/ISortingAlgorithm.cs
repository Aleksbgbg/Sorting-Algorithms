namespace Sorting.Algorithms.Core.Interfaces
{
    using System.Collections.Generic;

    internal interface ISortingAlgorithm<T>
    {
        T[] Sort(IEnumerable<T> elements);
    }
}