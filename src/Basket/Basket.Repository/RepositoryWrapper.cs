using Basket.Repository.BaseWrapper;
using Basket.Repository.Interfaces;
namespace Basket.Repository;
public class RepositoryWrapper : RepositoryWrapperBase<RepositoryContext>, IRepositoryWrapper
{
    public RepositoryWrapper(RepositoryContext context) : base(context)
    {
    }
    IBasketRepository basket { get; set; }
    public IBasketRepository Basket
    {
        get
        {
            if (basket == null)
            {
                basket = new BasketRepository(_dbContext);
            }
            return basket;
        }
    }
}
