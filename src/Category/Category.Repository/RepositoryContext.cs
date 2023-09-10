using Microsoft.EntityFrameworkCore;
using Generate = Category.Model.Generate;
namespace Category.Repository;
public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Generate.Category> Category { get; set; }
}
