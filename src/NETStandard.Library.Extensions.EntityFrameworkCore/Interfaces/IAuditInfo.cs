namespace NETStandard.Library.Extensions.EntityFrameworkCore.Interfaces
{
    using System;

    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        bool PreserveCreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}