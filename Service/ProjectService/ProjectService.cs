using DataModel.Entities;
using Microsoft.EntityFrameworkCore;
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
            return _dataContext.Projects
                .Include(project => project.Logs)
                .FirstOrDefault(project => projectKey.Equals(project.Key))
                ?? throw new NotFoundException(projectKey);
        }

        public void LogTime(LogTimeDTO logTimeDTO)
        {
            if (logTimeDTO.Duration.TotalMinutes < 30)
            {
                throw new TooShortDurationException();
            }

            var project = GetProject(logTimeDTO.ProjectKey);
            if (project.Deadline != null &&
                project.Deadline < DateTime.Now)
            {
                throw new ProjectOverdueException();
            }
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

        public List<Project> GetAllProjects()
        {
            return _dataContext.Projects.OrderByDescending(project => project.Deadline).ToList();
        }
    }
}
