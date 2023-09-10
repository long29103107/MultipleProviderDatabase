using Product.Repository.Interfaces;
using Product.Service.Interfaces;
namespace Product.Service;
public class BaseService : IBaseService
{
    protected readonly IRepositoryWrapper _wrapper;
    public BaseService(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
    }
}
