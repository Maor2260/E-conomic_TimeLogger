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
    }
}
