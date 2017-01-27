﻿namespace NETStandard.Library.Extensions.Infrastructure.Interfaces
{
    using System;

    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}