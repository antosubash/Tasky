using System;
using Volo.Abp.Application.Dtos;

namespace Tasky.ProjectService;

public class ProjectDto : EntityDto<Guid>
{
    public string Name { get; set; }
}
