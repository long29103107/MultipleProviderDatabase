using Microsoft.EntityFrameworkCore;
using Brand.Repository.Interfaces;
using Generate = Brand.Model.Generate;
namespace Brand.Repository;
public class BrandRepository : RepositoryBase<Generate.Brand, DbContext>, IBrandRepository
{
    public BrandRepository(DbContext context) : base(context)
    {
    }
    public override void BeforeAdd(Generate.Brand model)
    {
        model.CreatedBy = "unknown";
        model.CreatedAt = DateTime.UtcNow;
        model.UpdatedBy = "unknown";
        model.UpdatedAt = DateTime.UtcNow;
    }
    public override void BeforeUpdate(Generate.Brand model)
    {
        model.UpdatedBy = "unknown";
        model.UpdatedAt = DateTime.UtcNow;
    }
    public override void BeforeDelete(Generate.Brand model)
    {
        model.DeletedBy = "unknown";
        model.DeletedAt = DateTime.UtcNow;
    }
}
