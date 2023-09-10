using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Customer.Repository.Interfaces;
using Customer.Service.DTO;
using Customer.Service.Interfaces;
using Generate = Customer.Model.Generate;
namespace Customer.Service;
public class CustomerService : BaseService, ICustomerService
{
    private readonly IMapper _mapper; 
    private readonly IValidatorFactory _validatorFactory;
    public CustomerService(IRepositoryWrapper wrapper, IMapper mapper, IValidatorFactory validatorFactory) : base(wrapper)
    {
        _mapper = mapper;
        _validatorFactory = validatorFactory;
    }
    public async Task<CustomerReponse> GetDetailAsync(int id)
    {
        var model = await GetCustomerAsync(id);
        var result = _mapper.Map<CustomerReponse>(model);
        return result;
    }
    public async Task<List<CustomerReponse>> GetListAsync(ListCustomerRequest request)
    {
        var listModel = await _wrapper.Customer.FindAll().ToListAsync();
        var result = _mapper.Map<List<CustomerReponse>>(listModel);
        return result;
    }
    public async Task<CustomerReponse> CreateAsync(CustomerCreateRequest request)
    {
        var model = new Generate.Customer();
        _mapper.Map<CustomerCreateRequest, Generate.Customer>(request, model);
        await ValidateCustomerAsync(model);
        _wrapper.Customer.Add(model);
        await _wrapper.SaveAsync();
        var result = _mapper.Map<CustomerReponse>(model);
        return result;
    }
    public async Task<CustomerReponse> UpdateAsync(int id, CustomerUpdateRequest request)
    {
        var model = await GetCustomerAsync(id);
        _mapper.Map<CustomerUpdateRequest, Generate.Customer>(request, model);
        await ValidateCustomerAsync(model);
        _wrapper.Customer.Update(model);
        await _wrapper.SaveAsync();
        var result = _mapper.Map<CustomerReponse>(model);
        return result;
    }
    public async Task DeleteAsync(int id)
    {
        var model = await GetCustomerAsync(id);
        _wrapper.Customer.Delete(model);
        await _wrapper.SaveAsync();
    }
    private async Task ValidateCustomerAsync(Generate.Customer model)
    {
        var validator = _validatorFactory.GetValidator<Generate.Customer>();
        var result = await validator.ValidateAsync(model);
        if (!result.IsValid)
            throw new Exception(string.Join(", ", result.Errors.Select(x => x.ErrorMessage)));
    }
    private async Task<Generate.Customer> GetCustomerAsync(int id)
    {
        var model = await _wrapper.Customer.FindByCondition(x => x.Id == id)
                                    .FirstOrDefaultAsync();
        if (model == null)
        {
            throw new Exception("Customer is not found !");
        }
        return model;
    }
}
