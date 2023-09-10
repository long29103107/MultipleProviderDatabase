using Microsoft.EntityFrameworkCore;
using Category.Repository.Interfaces;
using Generate = Category.Model.Generate;
namespace Category.Repository;
public class CategoryRepository : RepositoryBase<Generate.Category, DbContext>, ICategoryRepository
{
    public CategoryRepository(DbContext context) : base(context)
    {
    }
    public override void BeforeAdd(Generate.Category model)
    {
        model.CreatedBy = "unknown";
        model.CreatedAt = DateTime.UtcNow;
        model.UpdatedBy = "unknown";
        model.UpdatedAt = DateTime.UtcNow;
    }
    public override void BeforeUpdate(Generate.Category model)
    {
        model.UpdatedBy = "unknown";
        model.UpdatedAt = DateTime.UtcNow;
    }
    public override void BeforeDelete(Generate.Category model)
    {
        model.DeletedBy = "unknown";
        model.DeletedAt = DateTime.UtcNow;
    }
}
