using Customer.Repository.BaseWrapper.Interfaces;
namespace Customer.Repository.Interfaces;
public interface IRepositoryWrapper : IRepositoryWrapperBase
{
    ICustomerRepository Customer { get; }
}
