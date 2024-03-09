using DataModel.Entities;
using Service.Data;

namespace Service.ProjectService
{
    public class ProjectService : IProjectSerivce
    {
        private readonly IDataContext _dataContext;

        public ProjectService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Project CreateProject(CreateProjectDTO createProjectDTO)
        {
            var project = createProjectEntity(createProjectDTO);
            _dataContext.Projects.Add(project);
            _dataContext.SaveChanges();
            return project;
        }

        private static Project createProjectEntity(CreateProjectDTO createProjectDTO)
        {
            return new DataModel.Entities.Project
            {
                Name = createProjectDTO.Name,
                Deadline = createProjectDTO.Deadline
            };
        }

        public Project GetProject(Guid projectKey)
        {
            return _dataContext.Projects.Find(projectKey) ??
                throw new NotFoundException(projectKey);
        }

        public void LogTime(LogTimeDTO logTimeDTO)
        {
            if (logTimeDTO.Duration.TotalMinutes < 30)
            {
                throw new TooShortDurationException();
            }

            var project = GetProject(logTimeDTO.ProjectKey);
            project.Logs.Add(createTimeLogEntity(logTimeDTO.Duration));
            _dataContext.SaveChanges();
        }

        private static TimeLog createTimeLogEntity(TimeSpan duration)
        {
            return new TimeLog()
            { 
                Duration = duration
            };
        }
    }
}
