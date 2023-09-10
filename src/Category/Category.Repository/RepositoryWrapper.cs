using Category.Repository.BaseWrapper;
using Category.Repository.Interfaces;
namespace Category.Repository;
public class RepositoryWrapper : RepositoryWrapperBase<RepositoryContext>, IRepositoryWrapper
{
    public RepositoryWrapper(RepositoryContext context) : base(context)
    {
    }
    ICategoryRepository category { get; set; }
    public ICategoryRepository Category
    {
        get
        {
            if (category == null)
            {
                category = new CategoryRepository(_dbContext);
            }
            return category;
        }
    }
}
