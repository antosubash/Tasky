using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Domain.Repositories;

namespace Tasky.ProjectService;

public class ProjectAppService : ProjectServiceAppService, IProjectAppService
{
    private readonly IRepository<Project, Guid> repository;

    public ProjectAppService(IRepository<Project, Guid> repository)
    {
        this.repository = repository;
    }

    [Authorize]    
    public async Task<List<ProjectDto>> GetAllAsync()
    {
        var projects = await repository.GetListAsync();
        return ObjectMapper.Map<List<Project>,List<ProjectDto>>(projects);
    }

    [Authorize]
    public async Task<ProjectDto> Create(ProjectDto projectDto)
    {
        var project = await repository.InsertAsync(new Project(projectDto.Name));
        return new ProjectDto
        {
            Name = project.Name
        };
    }
}
