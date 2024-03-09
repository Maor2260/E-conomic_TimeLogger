using Service.Data;

namespace Service.Project
{
    public class ProjectService : IProjectSerivce
    {
        private readonly IDataContext _dataContext;

        public ProjectService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public DataModel.Entities.Project CreateProject(CreateProjectDTO createProjectDTO)
        {
            var project = createProjectEntity(createProjectDTO);
            _dataContext.Projects.Add(project);
            _dataContext.SaveChanges();
            return project;
        }

        private static DataModel.Entities.Project createProjectEntity(CreateProjectDTO createProjectDTO)
        {
            return new DataModel.Entities.Project
            {
                Name = createProjectDTO.Name,
                Deadline = createProjectDTO.Deadline
            };
        }

        public DataModel.Entities.Project GetProject(Guid projectKey)
        {
            return _dataContext.Projects.Find(projectKey) ??
                throw new NotFoundException(projectKey);
        }
    }
}
