using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Basket.Repository.Interfaces;
using Basket.Service.DTO;
using Basket.Service.Interfaces;
using Generate = Basket.Model.Generate;
namespace Basket.Service;
public class BasketService : BaseService, IBasketService
{
    private readonly IMapper _mapper; 
    private readonly IValidatorFactory _validatorFactory;
    public BasketService(IRepositoryWrapper wrapper, IMapper mapper, IValidatorFactory validatorFactory) : base(wrapper)
    {
        _mapper = mapper;
        _validatorFactory = validatorFactory;
    }
    public async Task<BasketReponse> GetDetailAsync(int id)
    {
        var model = await GetBasketAsync(id);
        var result = _mapper.Map<BasketReponse>(model);
        return result;
    }
    public async Task<List<BasketReponse>> GetListAsync(ListBasketRequest request)
    {
        var listModel = await _wrapper.Basket.FindAll().ToListAsync();
        var result = _mapper.Map<List<BasketReponse>>(listModel);
        return result;
    }
    public async Task<BasketReponse> CreateAsync(BasketCreateRequest request)
    {
        var model = new Generate.Basket();
        _mapper.Map<BasketCreateRequest, Generate.Basket>(request, model);
        await ValidateBasketAsync(model);
        _wrapper.Basket.Add(model);
        await _wrapper.SaveAsync();
        var result = _mapper.Map<BasketReponse>(model);
        return result;
    }
    public async Task<BasketReponse> UpdateAsync(int id, BasketUpdateRequest request)
    {
        var model = await GetBasketAsync(id);
        _mapper.Map<BasketUpdateRequest, Generate.Basket>(request, model);
        await ValidateBasketAsync(model);
        _wrapper.Basket.Update(model);
        await _wrapper.SaveAsync();
        var result = _mapper.Map<BasketReponse>(model);
        return result;
    }
    public async Task DeleteAsync(int id)
    {
        var model = await GetBasketAsync(id);
        _wrapper.Basket.Delete(model);
        await _wrapper.SaveAsync();
    }
    private async Task ValidateBasketAsync(Generate.Basket model)
    {
        var validator = _validatorFactory.GetValidator<Generate.Basket>();
        var result = await validator.ValidateAsync(model);
        if (!result.IsValid)
            throw new Exception(string.Join(", ", result.Errors.Select(x => x.ErrorMessage)));
    }
    private async Task<Generate.Basket> GetBasketAsync(int id)
    {
        var model = await _wrapper.Basket.FindByCondition(x => x.Id == id)
                                    .FirstOrDefaultAsync();
        if (model == null)
        {
            throw new Exception("Basket is not found !");
        }
        return model;
    }
}
