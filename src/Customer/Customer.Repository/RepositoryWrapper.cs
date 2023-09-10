using Customer.Repository.BaseWrapper;
using Customer.Repository.Interfaces;
namespace Customer.Repository;
public class RepositoryWrapper : RepositoryWrapperBase<RepositoryContext>, IRepositoryWrapper
{
    public RepositoryWrapper(RepositoryContext context) : base(context)
    {
    }
    ICustomerRepository customer { get; set; }
    public ICustomerRepository Customer
    {
        get
        {
            if (customer == null)
            {
                customer = new CustomerRepository(_dbContext);
            }
            return customer;
        }
    }
}
