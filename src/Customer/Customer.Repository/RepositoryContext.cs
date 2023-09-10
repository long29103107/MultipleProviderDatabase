using Microsoft.EntityFrameworkCore;
using Generate = Customer.Model.Generate;
namespace Customer.Repository;
public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Generate.Customer> Customer { get; set; }
}
