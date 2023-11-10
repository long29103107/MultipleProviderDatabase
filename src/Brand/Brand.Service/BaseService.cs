using Brand.Repository.Interfaces;
using Brand.Service.Interfaces;
namespace Brand.Service;
public class BaseService : IBaseService
{
    protected readonly IRepositoryWrapper _wrapper;
    public BaseService(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
    }
}
