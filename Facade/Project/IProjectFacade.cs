using Microsoft.AspNetCore.Mvc;

namespace Facade.Project
{
    public interface IProjectFacade
    {
        public ActionResult<CreateProjectResponse> CreateProject(CreateProjectRequest createProjectRequest);
    }
}
