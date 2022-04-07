using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Tasky.ProjectService;

[Area(ProjectServiceRemoteServiceConsts.ModuleName)]
[RemoteService(Name = ProjectServiceRemoteServiceConsts.RemoteServiceName)]
[Route("api/ProjectService")]
public class ProjectController : ProjectServiceController, IProjectAppService
{
    private readonly IProjectAppService _projectService;

    public ProjectController(IProjectAppService sampleAppService)
    {
        _projectService = sampleAppService;
    }

    [HttpGet]
    public async Task<List<ProjectDto>> GetAllAsync()
    {
        return await _projectService.GetAllAsync();
    }

    
    [HttpPost]    
    public async Task<ProjectDto> Create(ProjectDto projectDto)
    {
        return await _projectService.Create(projectDto);
    }
}
