using Category.Repository.BaseWrapper.Interfaces;
namespace Category.Repository.Interfaces;
public interface IRepositoryWrapper : IRepositoryWrapperBase
{
    ICategoryRepository Category { get; }
}
