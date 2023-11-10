using Microsoft.EntityFrameworkCore;
using Generate = Brand.Model.Generate;
namespace Brand.Repository;
public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Generate.Brand> Brand { get; set; }
}
