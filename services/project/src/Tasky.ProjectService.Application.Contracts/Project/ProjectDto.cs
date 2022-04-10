using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Tasky.ProjectService
{
    public class ProjectDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
