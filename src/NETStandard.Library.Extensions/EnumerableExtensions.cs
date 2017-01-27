namespace NETStandard.Library.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines a helper class that provides extension methods over <see cref="IEnumerable{T}" /> collections.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Checks if the <see cref="IEnumerable{T}" /> is null or empty.
        /// </summary>
        /// <typeparam name="T">The item type of the items enumeration.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}" /> instance on which the extension method is called.</param>
        /// <returns>True if the collection is null or empty, false otherwise.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) => source == null || !source.Any();

        /// <summary>
        /// Checks if the <see cref="ICollection{T}" /> is null or empty.
        /// </summary>
        /// <typeparam name="T">The item type of the items enumeration.</typeparam>
        /// <param name="source">The <see cref="ICollection{T}" /> instance on which the extension method is called.</param>
        /// <returns>True if the collection is null or empty, false otherwise.</returns>
        public static bool IsNullOrEmpty<T>(this ICollection<T> source) => source == null || source.Count == 0;
    }
}