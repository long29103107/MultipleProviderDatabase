using Customer.Service.DTO;
namespace Customer.Service.Interfaces;
public interface ICustomerService : IBaseService
{
    Task<List<CustomerReponse>> GetListAsync(ListCustomerRequest request);
    Task<CustomerReponse> GetDetailAsync(int id);
    Task<CustomerReponse> CreateAsync(CustomerCreateRequest request);
    Task<CustomerReponse> UpdateAsync(int id, CustomerUpdateRequest request);
    Task DeleteAsync(int id);
}
