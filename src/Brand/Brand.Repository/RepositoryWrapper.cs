using Brand.Repository.BaseWrapper;
using Brand.Repository.Interfaces;
namespace Brand.Repository;
public class RepositoryWrapper : RepositoryWrapperBase<RepositoryContext>, IRepositoryWrapper
{
    public RepositoryWrapper(RepositoryContext context) : base(context)
    {
    }
    IBrandRepository brand { get; set; }
    public IBrandRepository Brand
    {
        get
        {
            if (brand == null)
            {
                brand = new BrandRepository(_dbContext);
            }
            return brand;
        }
    }
}
