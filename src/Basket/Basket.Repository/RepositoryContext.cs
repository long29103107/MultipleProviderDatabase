using Microsoft.EntityFrameworkCore;
using Generate = Basket.Model.Generate;
namespace Basket.Repository;
public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Generate.Basket> Basket { get; set; }
}
