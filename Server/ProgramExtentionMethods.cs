using Server.Data;

public static class ProgramExtentionMethods
{
    public static void AddDataContext(this IServiceCollection service)
    {
        service.AddDbContext<DataContext>();
    }
}
