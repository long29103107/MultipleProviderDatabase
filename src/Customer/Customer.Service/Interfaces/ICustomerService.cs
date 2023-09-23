using Customer.Service.DTO;
namespace Customer.Service.Interfaces;
public interface ICustomerService : IBaseService
{
    Task<List<CustomerResponse>> GetListAsync(ListCustomerRequest request);
    Task<CustomerResponse> GetDetailAsync(string id);
    Task<CustomerResponse> CreateAsync(CustomerCreateRequest request);
    Task<CustomerResponse> UpdateAsync(string id, CustomerUpdateRequest request);
    Task DeleteAsync(string id);
}
