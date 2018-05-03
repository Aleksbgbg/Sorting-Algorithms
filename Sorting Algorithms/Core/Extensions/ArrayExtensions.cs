namespace Sorting.Algorithms.Core.Extensions
{
    internal static class ArrayExtensions
    {
        internal static void Swap<T>(this T[] array, int indexFirst, int indexSecond)
        {
            T temporary = array[indexFirst];
            array[indexFirst] = array[indexSecond];
            array[indexSecond] = temporary;
        }
    }
}