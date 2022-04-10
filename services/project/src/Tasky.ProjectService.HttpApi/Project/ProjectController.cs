using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Tasky.ProjectService
{
    [Area(ProjectServiceRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = ProjectServiceRemoteServiceConsts.RemoteServiceName)]
    [Route("api/project")]
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
}
