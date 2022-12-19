﻿using Silky.EntityFrameworkCore.Entities;

namespace Silky.WorkFlow.Domain
{
    public class BusinessCategory : Entity<long>
    {
        public string BusinessCategoryCode { get; set; }
        public string BusinessCategoryName { get; set; }
    }
}
