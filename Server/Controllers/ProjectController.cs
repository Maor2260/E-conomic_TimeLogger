using Facade.Project;
using Microsoft.AspNetCore.Mvc;
using Service.Project;

namespace Server.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectController : Controller, IProjectFacade
    {
        private readonly IProjectSerivce _projectSerivce;

        public ProjectController(IProjectSerivce projectSerivce)
        {
            _projectSerivce = projectSerivce;
        }

        [HttpPut]
        [Route("create")]
        public ActionResult<CreateProjectResponse> CreateProject(CreateProjectRequest createProjectRequest)
        {
            var project = _projectSerivce.CreateProject(toDto(createProjectRequest));
            return Ok(new CreateProjectResponse(project.Key));
        }

        private CreateProjectDTO toDto(CreateProjectRequest createProjectRequest)
        {
            return new CreateProjectDTO(createProjectRequest.Name, createProjectRequest.Deadline);
        }
    }
}
