using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Brand.Repository.Interfaces;
using Brand.Service.DTO;
using Brand.Service.Interfaces;
using Generate = Brand.Model.Generate;
namespace Brand.Service;
public class BrandService : BaseService, IBrandService
{
    private readonly IMapper _mapper; 
    private readonly IValidatorFactory _validatorFactory;
    public BrandService(IRepositoryWrapper wrapper, IMapper mapper, IValidatorFactory validatorFactory) : base(wrapper)
    {
        _mapper = mapper;
        _validatorFactory = validatorFactory;
    }
    public async Task<BrandReponse> GetDetailAsync(int id)
    {
        var model = await GetBrandAsync(id);
        var result = _mapper.Map<BrandReponse>(model);
        return result;
    }
    public async Task<List<BrandReponse>> GetListAsync(ListBrandRequest request)
    {
        var listModel = await _wrapper.Brand.FindAll().ToListAsync();
        var result = _mapper.Map<List<BrandReponse>>(listModel);
        return result;
    }
    public async Task<BrandReponse> CreateAsync(BrandCreateRequest request)
    {
        var model = new Generate.Brand();
        _mapper.Map<BrandCreateRequest, Generate.Brand>(request, model);
        await ValidateBrandAsync(model);
        _wrapper.Brand.Add(model);
        await _wrapper.SaveAsync();
        var result = _mapper.Map<BrandReponse>(model);
        return result;
    }
    public async Task<BrandReponse> UpdateAsync(int id, BrandUpdateRequest request)
    {
        var model = await GetBrandAsync(id);
        _mapper.Map<BrandUpdateRequest, Generate.Brand>(request, model);
        await ValidateBrandAsync(model);
        _wrapper.Brand.Update(model);
        await _wrapper.SaveAsync();
        var result = _mapper.Map<BrandReponse>(model);
        return result;
    }
    public async Task DeleteAsync(int id)
    {
        var model = await GetBrandAsync(id);
        _wrapper.Brand.Delete(model);
        await _wrapper.SaveAsync();
    }
    private async Task ValidateBrandAsync(Generate.Brand model)
    {
        var validator = _validatorFactory.GetValidator<Generate.Brand>();
        var result = await validator.ValidateAsync(model);
        if (!result.IsValid)
            throw new Exception(string.Join(", ", result.Errors.Select(x => x.ErrorMessage)));
    }
    private async Task<Generate.Brand> GetBrandAsync(int id)
    {
        var model = await _wrapper.Brand.FindByCondition(x => x.Id == id)
                                    .FirstOrDefaultAsync();
        if (model == null)
        {
            throw new Exception("Brand is not found !");
        }
        return model;
    }
}
