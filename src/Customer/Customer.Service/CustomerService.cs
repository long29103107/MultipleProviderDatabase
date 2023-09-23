using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Customer.Repository.Interfaces;
using Customer.Service.DTO;
using Customer.Service.Interfaces;
using Generate = Customer.Model.Generate;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Customer.Service;
public class CustomerService : BaseService, ICustomerService
{
    private readonly IMapper _mapper; 
    private readonly IValidatorFactory _validatorFactory;
    private readonly ICustomerRepository _repository;
    public CustomerService(IMapper mapper, IValidatorFactory validatorFactory, ICustomerRepository repository)
    {
        _mapper = mapper;
        _validatorFactory = validatorFactory;
        _repository = repository;
    }
    public async Task<CustomerResponse> GetDetailAsync(string id)
    {
        var model = await GetCustomerAsync(id);
        var result = _mapper.Map<CustomerResponse>(model);
        return result;
    }
    public async Task<List<CustomerResponse>> GetListAsync(ListCustomerRequest request)
    {
        var listModel = await _repository.GetAllAsync();
        var result = _mapper.Map<List<CustomerResponse>>(listModel);
        return result;
    }
    public async Task<CustomerResponse> CreateAsync(CustomerCreateRequest request)
    {
        var model = new Generate.Customer();
        _mapper.Map<CustomerCreateRequest, Generate.Customer>(request, model);
        await ValidateCustomerAsync(model);
        await _repository.AddAsync(model);

        var result = _mapper.Map<CustomerResponse>(model);
        return result;
    }
    public async Task<CustomerResponse> UpdateAsync(string id, CustomerUpdateRequest request)
    {
        var model = await GetCustomerAsync(id);
        _mapper.Map<CustomerUpdateRequest, Generate.Customer>(request, model);
        await ValidateCustomerAsync(model);
        await _repository.UpdateAsync( model);

        var result = _mapper.Map<CustomerResponse>(model);
        return result;
    }
    public async Task DeleteAsync(string id)
    {
        var model = await GetCustomerAsync(id);
        await _repository.RemoveAsync(id);
    }
    private async Task ValidateCustomerAsync(Generate.Customer model)
    {
        var validator = _validatorFactory.GetValidator<Generate.Customer>();
        var result = await validator.ValidateAsync(model);
        if (!result.IsValid)
            throw new Exception(string.Join(", ", result.Errors.Select(x => x.ErrorMessage)));
    }
    private async Task<Generate.Customer> GetCustomerAsync(string id)
    {
        var model = await _repository.GetByIdAsync(id);
        if (model == null)
        {
            throw new Exception("Customer is not found !");
        }
        return model;
    }
}
