namespace Facade.Project
{
    [Serializable]
    public class CreateProjectResponse
    {
        public Guid ProjectKey { get; set; }

        public CreateProjectResponse(Guid projectKey)
        {
            ProjectKey = projectKey;
        }
    }
}
