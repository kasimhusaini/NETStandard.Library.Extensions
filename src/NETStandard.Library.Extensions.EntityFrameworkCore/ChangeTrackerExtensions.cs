namespace NETStandard.Library.Extensions.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using NETStandard.Library.Extensions.Infrastructure.Interfaces;

    /// <summary>
    /// Defines a helper class that provides extension methods over <see cref="ChangeTracker" /> object.
    /// </summary>
    public static class ChangeTrackerExtensions
    {
        /// <summary>
        /// Applies audit info rules for added or modified entities in change tracker.
        /// </summary>
        /// <param name="changeTracker">The change tracker.</param>
        /// <remarks>Approach via @julielerman: <see cref="http://bit.ly/123661P"/></remarks>
        public static void ApplyAuditInfoRules(this ChangeTracker changeTracker)
        {
            if (changeTracker == null)
            {
                throw new ArgumentNullException(nameof(changeTracker));
            }

            foreach (var entry in changeTracker.Entries().Where(e => e.Entity is IAuditInfo &&
                                                                   (e.State == EntityState.Added ||
                                                                    e.State == EntityState.Modified)))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Tries to validate all added or modified entities in change tracker.
        /// </summary>
        /// <param name="changeTracker">The change tracker.</param>
        public static void TryValidateModifiedEntities(this ChangeTracker changeTracker)
        {
            var items = new Dictionary<object, object>();

            foreach (var entry in changeTracker.Entries().Where(e => (e.State == EntityState.Added) || (e.State == EntityState.Modified)))
            {
                var entity = entry.Entity;
                var context = new ValidationContext(entity, items);
                var results = new List<ValidationResult>();

                if (!Validator.TryValidateObject(entity, context, results, true))
                {
                    foreach (var result in results)
                    {
                        if (result != ValidationResult.Success)
                        {
                            throw new ValidationException(result.ErrorMessage);
                        }
                    }
                }
            }
        }
    }
}
