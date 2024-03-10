using DataModel.Entities;
using Facade.Project;
using Microsoft.AspNetCore.Mvc;
using Service.ProjectService;

namespace Server.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectController : Controller, IProjectFacade
    {
        private readonly IProjectService _projectSerivce;

        public ProjectController(IProjectService projectSerivce)
        {
            _projectSerivce = projectSerivce;
        }

        [HttpPut]
        [Route("create")]
        public ActionResult<CreateProjectResponse> CreateProject(CreateProjectRequest createProjectRequest)
        {
            try
            {
                var project = _projectSerivce.CreateProject(toDto(createProjectRequest));
                return Ok(new CreateProjectResponse(project.Key));
            } 
            catch (Exception e)
            {
                return BadRequest(e.GetType().Name);
            }
        }

        private CreateProjectDTO toDto(CreateProjectRequest createProjectRequest)
        {
            return new CreateProjectDTO(createProjectRequest.Name, createProjectRequest.Deadline);
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<ProjectExternal> GetProject([FromQuery] Guid projectKey)
        {
            try
            {
                var project = _projectSerivce.GetProject(projectKey);
                return Ok(toExternal(project));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        private ProjectExternal toExternal(Project project)
        {
            return new ProjectExternal()
            {
                Name = project.Name,
                Deadline = project.Deadline,
                Records = project.Logs.Select(log => toExternal(log)).ToList()
            };
        }

        private Duration toExternal(TimeLog timeLog)
        {
            return new Duration(timeLog.Duration);
        }

        [HttpPost]
        [Route("logtime")]
        public ActionResult LogTime(LogTimeRequest logTimeRequest)
        {
            try
            {
                _projectSerivce.LogTime(new LogTimeDTO(logTimeRequest.ProjectKey, logTimeRequest.Duration.ToTimeSpan()));
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.GetType().Name);
            }
        }

        [HttpGet]
        [Route("getoverview")]
        public ActionResult<GetOverviewRespond> GetOverview()
        {
            var projects = _projectSerivce.GetAllProjects();
            return Ok(new GetOverviewRespond(projects.Select(project => toExternal(project)).ToList()));
        }
    }
}
