namespace NETStandard.Library.Extensions.Infrastructure.Mappings
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Model builder configuration interface.
    /// </summary>
    public interface IFluentMapping
    {
        /// <summary>
        /// Method for configuring the shape of entities, the relationships between them, and how they map to the database.
        /// </summary>
        /// <param name="modelBuilder">The module builder.</param>
        void Configure(ModelBuilder modelBuilder);
    }
}