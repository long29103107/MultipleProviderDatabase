using SubCategory.Repository.BaseWrapper;
using SubCategory.Repository.Interfaces;
namespace SubCategory.Repository;
public class RepositoryWrapper : RepositoryWrapperBase<RepositoryContext>, IRepositoryWrapper
{
    public RepositoryWrapper(RepositoryContext context) : base(context)
    {
    }
    ISubCategoryRepository subcategory { get; set; }
    public ISubCategoryRepository SubCategory
    {
        get
        {
            if (subcategory == null)
            {
                subcategory = new SubCategoryRepository(_dbContext);
            }
            return subcategory;
        }
    }
}
