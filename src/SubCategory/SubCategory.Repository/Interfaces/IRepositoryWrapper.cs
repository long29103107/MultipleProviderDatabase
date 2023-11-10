using SubCategory.Repository.BaseWrapper.Interfaces;
namespace SubCategory.Repository.Interfaces;
public interface IRepositoryWrapper : IRepositoryWrapperBase
{
    ISubCategoryRepository SubCategory { get; }
}
