using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Tasky.ProjectService
{
    public class Project : AggregateRoot<Guid>, IMultiTenant
    {
        public string Name { get; set; }

        public Guid? TenantId { get; set; }

        public Project(string name)
        {
            Name = name;
        }
    }
}
