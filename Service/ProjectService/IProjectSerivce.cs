using DataModel.Entities;

namespace Service.ProjectService
{
    public interface IProjectSerivce
    {
        public Project CreateProject(CreateProjectDTO createProjectDTO);

        public Project GetProject(Guid projectKey);

        public void LogTime(LogTimeDTO logTimeDTO);

        public List<Project> GetAllProjects();
    }
}
