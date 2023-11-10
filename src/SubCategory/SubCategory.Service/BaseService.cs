using SubCategory.Repository.Interfaces;
using SubCategory.Service.Interfaces;
namespace SubCategory.Service;
public class BaseService : IBaseService
{
    protected readonly IRepositoryWrapper _wrapper;
    public BaseService(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
    }
}
