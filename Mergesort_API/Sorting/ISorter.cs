namespace Mergesort_API
{
    /// <summary>
    /// The Sorter interface.
    /// </summary>
    /// <typeparam name="T">The type that is sorted by the sorter.</typeparam>
    public interface ISorter<T>
    {
        /// <summary>
        /// Sorts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>A sorted array of T.</returns>
        T[] Sort(T[] input);
    }
}