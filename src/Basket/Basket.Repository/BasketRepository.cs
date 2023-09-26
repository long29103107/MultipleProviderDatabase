using Microsoft.EntityFrameworkCore;
using Basket.Repository.Interfaces;
using Generate = Basket.Model.Generate;
namespace Basket.Repository;
public class BasketRepository : RepositoryBase<Generate.Basket, DbContext>, IBasketRepository
{
    public BasketRepository(DbContext context) : base(context)
    {
    }
    public override void BeforeAdd(Generate.Basket model)
    {
        model.CreatedBy = "unknown";
        model.CreatedAt = DateTime.UtcNow;
        model.UpdatedBy = "unknown";
        model.UpdatedAt = DateTime.UtcNow;
    }
    public override void BeforeUpdate(Generate.Basket model)
    {
        model.UpdatedBy = "unknown";
        model.UpdatedAt = DateTime.UtcNow;
    }
    public override void BeforeDelete(Generate.Basket model)
    {
        model.DeletedBy = "unknown";
        model.DeletedAt = DateTime.UtcNow;
    }
}
