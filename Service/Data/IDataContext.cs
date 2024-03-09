using Microsoft.EntityFrameworkCore;

namespace Service.Data
{
    public interface IDataContext
    {
        public int SaveChanges();

        public DbSet<DataModel.Entities.Project> Projects { get; }
    }
}
