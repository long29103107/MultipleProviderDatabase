using Basket.Repository.Interfaces;
using Basket.Service.Interfaces;
namespace Basket.Service;
public class BaseService : IBaseService
{
    protected readonly IRepositoryWrapper _wrapper;
    public BaseService(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
    }
}
