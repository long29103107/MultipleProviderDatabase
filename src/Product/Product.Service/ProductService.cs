using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Product.Repository.Interfaces;
using Product.Service.DTO;
using Product.Service.Interfaces;
using Generate = Product.Model.Generate;
namespace Product.Service;
public class ProductService : BaseService, IProductService
{
    private readonly IMapper _mapper; 
    private readonly IValidatorFactory _validatorFactory;
    public ProductService(IRepositoryWrapper wrapper, IMapper mapper, IValidatorFactory validatorFactory) : base(wrapper)
    {
        _mapper = mapper;
        _validatorFactory = validatorFactory;
    }
    public async Task<ProductReponse> GetDetailAsync(int id)
    {
        var model = await GetProductAsync(id);
        var result = _mapper.Map<ProductReponse>(model);
        return result;
    }
    public async Task<List<ProductReponse>> GetListAsync(ListProductRequest request)
    {
        var listModel = await _wrapper.Product.FindAll().ToListAsync();
        var result = _mapper.Map<List<ProductReponse>>(listModel);
        return result;
    }
    public async Task<ProductReponse> CreateAsync(ProductCreateRequest request)
    {
        var model = new Generate.Product();
        _mapper.Map<ProductCreateRequest, Generate.Product>(request, model);
        await ValidateProductAsync(model);
        _wrapper.Product.Add(model);
        await _wrapper.SaveAsync();
        var result = _mapper.Map<ProductReponse>(model);
        return result;
    }
    public async Task<ProductReponse> UpdateAsync(int id, ProductUpdateRequest request)
    {
        var model = await GetProductAsync(id);
        _mapper.Map<ProductUpdateRequest, Generate.Product>(request, model);
        await ValidateProductAsync(model);
        _wrapper.Product.Update(model);
        await _wrapper.SaveAsync();
        var result = _mapper.Map<ProductReponse>(model);
        return result;
    }
    public async Task DeleteAsync(int id)
    {
        var model = await GetProductAsync(id);
        _wrapper.Product.Delete(model);
        await _wrapper.SaveAsync();
    }
    private async Task ValidateProductAsync(Generate.Product model)
    {
        var validator = _validatorFactory.GetValidator<Generate.Product>();
        var result = await validator.ValidateAsync(model);
        if (!result.IsValid)
            throw new Exception(string.Join(", ", result.Errors.Select(x => x.ErrorMessage)));
    }
    private async Task<Generate.Product> GetProductAsync(int id)
    {
        var model = await _wrapper.Product.FindByCondition(x => x.Id == id)
                                    .FirstOrDefaultAsync();
        if (model == null)
        {
            throw new Exception("Product is not found !");
        }
        return model;
    }
}
