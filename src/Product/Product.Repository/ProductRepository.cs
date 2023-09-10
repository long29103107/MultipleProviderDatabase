using Microsoft.EntityFrameworkCore;
using Product.Repository.Interfaces;
using Shared.Repository.RepositoryBase;
using Generate = Product.Model.Generate;
namespace Product.Repository;
public class ProductRepository : RepositoryBase<Generate.Product, DbContext>, IProductRepository
{
    public ProductRepository(DbContext context) : base(context)
    {
    }
    public override void BeforeAdd(Generate.Product model)
    {
        model.CreatedBy = "unknown";
        model.CreatedAt = DateTime.UtcNow;
        model.UpdatedBy = "unknown";
        model.UpdatedAt = DateTime.UtcNow;
    }
    public override void BeforeUpdate(Generate.Product model)
    {
        model.UpdatedBy = "unknown";
        model.UpdatedAt = DateTime.UtcNow;
    }
    public override void BeforeDelete(Generate.Product model)
    {
        model.DeletedBy = "unknown";
        model.DeletedAt = DateTime.UtcNow;
    }
}
