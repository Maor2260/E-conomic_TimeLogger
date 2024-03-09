namespace Service.Project
{
    public interface IProjectSerivce
    {
        public DataModel.Entities.Project CreateProject(CreateProjectDTO createProjectDTO);
    }
}
