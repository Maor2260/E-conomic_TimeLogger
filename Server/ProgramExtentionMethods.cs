using Server.Data;
using Service.Data;
using Service.ProjectService;

public static class ProgramExtentionMethods
{
    public static void AddDataContext(this IServiceCollection service)
    {
        service.AddDbContext<DataContext>();
    }

    public static void AddDependencyInjections(this IServiceCollection service)
    {
        service.AddScoped<IDataContext, DataContext>();
        service.AddScoped<IProjectSerivce, ProjectService>();
    }
}
