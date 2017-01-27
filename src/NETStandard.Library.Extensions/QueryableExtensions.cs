namespace NETStandard.Library.Extensions
{
    using System.Linq;
    using NETStandard.Library.Extensions.Interfaces;

    /// <summary>
    /// Defines a helper class that provides extension methods over <see cref="IQueryable" /> interface.
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Sorts an <see cref="IOrderable" /> collection by its ordinal value in ascending order.
        /// </summary>
        /// <typeparam name="T">The type of collection entities.</typeparam>
        /// <param name="collection">The collection to sort.</param>
        /// <returns>The collection sorted by order value in ascending order.</returns>
        public static IQueryable<T> SortByOrdinal<T>(this IQueryable<T> collection) where T : IOrderable
        {
            return collection.OrderBy(x => x.Ordinal);
        }
    }
}