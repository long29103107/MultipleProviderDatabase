using Microsoft.EntityFrameworkCore;
using Generate = Product.Model.Generate;
namespace Product.Repository;
public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Generate.Product> Product { get; set; }
}
