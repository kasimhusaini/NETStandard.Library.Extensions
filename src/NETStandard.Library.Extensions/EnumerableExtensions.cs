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

        /// <summary>
        /// Concatenates the members of a collection, using the specified separator between each member.
        /// </summary>
        /// <typeparam name="T">The type of the members of values.</typeparam>
        /// <param name="values">A collection that contains the objects to concatenate.</param>
        /// <param name="separator">
        /// The string to use as a separator. separator is included in the returned string only if values
        /// has more than one element.
        /// </param>
        /// <returns>
        /// A string that consists of the members of values delimited by the separator string. If values has no members,
        /// the method returns System.String.Empty.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">values is null.</exception>
        public static string Join<T>(this IEnumerable<T> values, string separator) => string.Join(separator, values);
    }
}