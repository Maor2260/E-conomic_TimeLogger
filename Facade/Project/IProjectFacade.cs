using Microsoft.AspNetCore.Mvc;

namespace Facade.Project
{
    public interface IProjectFacade
    {
        public ActionResult<CreateProjectResponse> CreateProject(CreateProjectRequest createProjectRequest);

        public ActionResult<ProjectExternal> GetProject([FromQuery] Guid projectKey);

        public ActionResult LogTime(LogTimeRequest logTimeRequest);

        public ActionResult<GetOverviewRespond> GetOverview();
    }
}
