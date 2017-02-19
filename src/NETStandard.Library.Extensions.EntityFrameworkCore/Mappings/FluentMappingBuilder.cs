namespace NETStandard.Library.Extensions.EntityFrameworkCore.Mappings
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Builder for configuring dynamically fluent mappings for given types.
    /// </summary>
    public static class FluentMappingBuilder
    {
        /// <summary>
        /// Registers entity fluent mappings from given assembly names.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        /// <param name="assemblies">The assembly collection.</param>
        public static void RegisterFluentMappings(this ModelBuilder modelBuilder, params Assembly[] assemblies)
        {
            if (assemblies == null || assemblies.Length == 0)
            {
                throw new ArgumentException($"The collection '{ nameof(assemblies) }' cannot be null or empty.");
            }

            var types = assemblies.SelectMany(a => a.GetTypes()).ToList();

            var fluentMappingTypes = types.Where(t => t.GetMethods().Any(m => m.Name == nameof(IFluentMapping.Configure))).ToList();
            fluentMappingTypes.ForEach(modelBuilder.RegisterFluentMapping);
        }

        /// <summary>
        /// Method for configuring the shape of entities, the relationships between them, and how they map to the database.
        /// </summary>
        /// <param name="modelBuilder">The module builder.</param>
        /// <param name="fluentMappingType">The fluent mapping type.</param>
        public static void RegisterFluentMapping(this ModelBuilder modelBuilder, Type fluentMappingType)
        {
            var fluentMappingInstance = Activator.CreateInstance(fluentMappingType);

            var method = fluentMappingType.GetMethod(nameof(IFluentMapping.Configure));
            method.Invoke(fluentMappingInstance, new object[] { modelBuilder });
        }
    }
}