using Shared.Repository.BaseWrapper;
using Product.Repository.Interfaces;
namespace Product.Repository;
public class RepositoryWrapper : RepositoryWrapperBase<RepositoryContext>, IRepositoryWrapper
{
    public RepositoryWrapper(RepositoryContext context) : base(context)
    {

    }
    IProductRepository product { get; set; }
    public IProductRepository Product
    {
        get
        {
            if (product == null)
            {
                product = new ProductRepository(_dbContext);
            }
            return product;
        }
    }
}
