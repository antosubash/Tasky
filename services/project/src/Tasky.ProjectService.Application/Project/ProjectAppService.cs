using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Tasky.ProjectService.Features;
using Tasky.ProjectService.Permissions;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Features;

namespace Tasky.ProjectService;

[RequiresFeature(ProjectServiceFeatures.Project.Default)]
[Authorize(ProjectServicePermissions.Project.Default)]
public class ProjectAppService : ProjectServiceAppService, IProjectAppService
{
    private readonly IRepository<Project, Guid> repository;

    public ProjectAppService(IRepository<Project, Guid> repository)
    {
        this.repository = repository;
    }

    [Authorize(ProjectServicePermissions.Project.Default)]    
    public async Task<List<ProjectDto>> GetAllAsync()
    {
        var projects = await repository.GetListAsync();
        return ObjectMapper.Map<List<Project>,List<ProjectDto>>(projects);
    }

    [Authorize(ProjectServicePermissions.Project.Create)]
    public async Task<ProjectDto> Create(ProjectDto projectDto)
    {
        var project = await repository.InsertAsync(new Project(projectDto.Name));
        return new ProjectDto
        {
            Name = project.Name
        };
    }
}
