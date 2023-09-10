using Category.Repository.Interfaces;
using Category.Service.Interfaces;
namespace Category.Service;
public class BaseService : IBaseService
{
    protected readonly IRepositoryWrapper _wrapper;
    public BaseService(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
    }
}
