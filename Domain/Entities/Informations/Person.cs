﻿namespace Domain.Domain.Entities.Information
{
    public class Person : BaseEntity
    {
        public string FullName { get; set; }

        public string GroupName { get; set; }

        public string JobTitle { get; set; }
    }
}
