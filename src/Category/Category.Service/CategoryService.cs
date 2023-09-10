using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Category.Repository.Interfaces;
using Category.Service.DTO;
using Category.Service.Interfaces;
using Generate = Category.Model.Generate;
namespace Category.Service;
public class CategoryService : BaseService, ICategoryService
{
    private readonly IMapper _mapper; 
    private readonly IValidatorFactory _validatorFactory;
    public CategoryService(IRepositoryWrapper wrapper, IMapper mapper, IValidatorFactory validatorFactory) : base(wrapper)
    {
        _mapper = mapper;
        _validatorFactory = validatorFactory;
    }
    public async Task<CategoryReponse> GetDetailAsync(int id)
    {
        var model = await GetCategoryAsync(id);
        var result = _mapper.Map<CategoryReponse>(model);
        return result;
    }
    public async Task<List<CategoryReponse>> GetListAsync(ListCategoryRequest request)
    {
        var listModel = await _wrapper.Category.FindAll().ToListAsync();
        var result = _mapper.Map<List<CategoryReponse>>(listModel);
        return result;
    }
    public async Task<CategoryReponse> CreateAsync(CategoryCreateRequest request)
    {
        var model = new Generate.Category();
        _mapper.Map<CategoryCreateRequest, Generate.Category>(request, model);
        await ValidateCategoryAsync(model);
        _wrapper.Category.Add(model);
        await _wrapper.SaveAsync();
        var result = _mapper.Map<CategoryReponse>(model);
        return result;
    }
    public async Task<CategoryReponse> UpdateAsync(int id, CategoryUpdateRequest request)
    {
        var model = await GetCategoryAsync(id);
        _mapper.Map<CategoryUpdateRequest, Generate.Category>(request, model);
        await ValidateCategoryAsync(model);
        _wrapper.Category.Update(model);
        await _wrapper.SaveAsync();
        var result = _mapper.Map<CategoryReponse>(model);
        return result;
    }
    public async Task DeleteAsync(int id)
    {
        var model = await GetCategoryAsync(id);
        _wrapper.Category.Delete(model);
        await _wrapper.SaveAsync();
    }
    private async Task ValidateCategoryAsync(Generate.Category model)
    {
        var validator = _validatorFactory.GetValidator<Generate.Category>();
        var result = await validator.ValidateAsync(model);
        if (!result.IsValid)
            throw new Exception(string.Join(", ", result.Errors.Select(x => x.ErrorMessage)));
    }
    private async Task<Generate.Category> GetCategoryAsync(int id)
    {
        var model = await _wrapper.Category.FindByCondition(x => x.Id == id)
                                    .FirstOrDefaultAsync();
        if (model == null)
        {
            throw new Exception("Category is not found !");
        }
        return model;
    }
}
