using Microsoft.EntityFrameworkCore;
using Generate = SubCategory.Model.Generate;
namespace SubCategory.Repository;
public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Generate.SubCategory> SubCategory { get; set; }
}
