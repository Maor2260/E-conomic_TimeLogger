namespace Service.Project
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Guid key) : base("No project with key: " + key.ToString())
        {
        }
    }
}
