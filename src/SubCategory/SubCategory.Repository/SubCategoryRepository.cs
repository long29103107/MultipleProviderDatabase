using Microsoft.EntityFrameworkCore;
using SubCategory.Repository.Interfaces;
using Generate = SubCategory.Model.Generate;
namespace SubCategory.Repository;
public class SubCategoryRepository : RepositoryBase<Generate.SubCategory, DbContext>, ISubCategoryRepository
{
    public SubCategoryRepository(DbContext context) : base(context)
    {
    }
    public override void BeforeAdd(Generate.SubCategory model)
    {
        model.CreatedBy = "unknown";
        model.CreatedAt = DateTime.UtcNow;
        model.UpdatedBy = "unknown";
        model.UpdatedAt = DateTime.UtcNow;
    }
    public override void BeforeUpdate(Generate.SubCategory model)
    {
        model.UpdatedBy = "unknown";
        model.UpdatedAt = DateTime.UtcNow;
    }
    public override void BeforeDelete(Generate.SubCategory model)
    {
        model.DeletedBy = "unknown";
        model.DeletedAt = DateTime.UtcNow;
    }
}
