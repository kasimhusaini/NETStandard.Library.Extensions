﻿namespace NETStandard.Library.Extensions.EntityFrameworkCore.Interfaces
{
    using System;

    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}