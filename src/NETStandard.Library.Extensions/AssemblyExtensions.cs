namespace NETStandard.Library.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Defines a helper class that provides extension methods over <see cref="Assembly" /> objects.
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Loads an assembly by given assembly name.
        /// </summary>
        /// <param name="assemblyName">The assembly name.</param>
        /// <returns>The loaded assembly.</returns>
        public static Assembly LoadAssembly(this string assemblyName)
        {
            if (assemblyName.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("The assembly name cannot be null, empty or white-space.", nameof(assemblyName));
            }

            var assembly = Assembly.Load(new AssemblyName(assemblyName));

            return assembly;
        }

        /// <summary>
        /// Loads assemblies by given assembly names collection.
        /// </summary>
        /// <param name="assemblyNames">The assembly names collection.</param>
        /// <returns>Collection of loaded assemblies.</returns>
        public static IEnumerable<Assembly> LoadAssemblies(this string[] assemblyNames)
        {
            if (assemblyNames.IsNullOrEmpty())
            {
                throw new ArgumentException("The assembly names collection cannot be null or empty.", nameof(assemblyNames));
            }

            var assemblies = assemblyNames.Select(a => a.LoadAssembly());

            return assemblies;
        }
    }
}