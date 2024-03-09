namespace Facade.Project
{
    [Serializable]
    public class GetOverviewRespond
    {
        public List<ProjectExternal> Projects { get; set; }

        public GetOverviewRespond(List<ProjectExternal> projects)
        {
            Projects = projects;
        }
    }
}
