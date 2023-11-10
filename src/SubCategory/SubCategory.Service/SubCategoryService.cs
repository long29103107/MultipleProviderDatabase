using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SubCategory.Repository.Interfaces;
using SubCategory.Service.DTO;
using SubCategory.Service.Interfaces;
using Generate = SubCategory.Model.Generate;
namespace SubCategory.Service;
public class SubCategoryService : BaseService, ISubCategoryService
{
    private readonly IMapper _mapper; 
    private readonly IValidatorFactory _validatorFactory;
    public SubCategoryService(IRepositoryWrapper wrapper, IMapper mapper, IValidatorFactory validatorFactory) : base(wrapper)
    {
        _mapper = mapper;
        _validatorFactory = validatorFactory;
    }
    public async Task<SubCategoryReponse> GetDetailAsync(int id)
    {
        var model = await GetSubCategoryAsync(id);
        var result = _mapper.Map<SubCategoryReponse>(model);
        return result;
    }
    public async Task<List<SubCategoryReponse>> GetListAsync(ListSubCategoryRequest request)
    {
        var listModel = await _wrapper.SubCategory.FindAll().ToListAsync();
        var result = _mapper.Map<List<SubCategoryReponse>>(listModel);
        return result;
    }
    public async Task<SubCategoryReponse> CreateAsync(SubCategoryCreateRequest request)
    {
        var model = new Generate.SubCategory();
        _mapper.Map<SubCategoryCreateRequest, Generate.SubCategory>(request, model);
        await ValidateSubCategoryAsync(model);
        _wrapper.SubCategory.Add(model);
        await _wrapper.SaveAsync();
        var result = _mapper.Map<SubCategoryReponse>(model);
        return result;
    }
    public async Task<SubCategoryReponse> UpdateAsync(int id, SubCategoryUpdateRequest request)
    {
        var model = await GetSubCategoryAsync(id);
        _mapper.Map<SubCategoryUpdateRequest, Generate.SubCategory>(request, model);
        await ValidateSubCategoryAsync(model);
        _wrapper.SubCategory.Update(model);
        await _wrapper.SaveAsync();
        var result = _mapper.Map<SubCategoryReponse>(model);
        return result;
    }
    public async Task DeleteAsync(int id)
    {
        var model = await GetSubCategoryAsync(id);
        _wrapper.SubCategory.Delete(model);
        await _wrapper.SaveAsync();
    }
    private async Task ValidateSubCategoryAsync(Generate.SubCategory model)
    {
        var validator = _validatorFactory.GetValidator<Generate.SubCategory>();
        var result = await validator.ValidateAsync(model);
        if (!result.IsValid)
            throw new Exception(string.Join(", ", result.Errors.Select(x => x.ErrorMessage)));
    }
    private async Task<Generate.SubCategory> GetSubCategoryAsync(int id)
    {
        var model = await _wrapper.SubCategory.FindByCondition(x => x.Id == id)
                                    .FirstOrDefaultAsync();
        if (model == null)
        {
            throw new Exception("SubCategory is not found !");
        }
        return model;
    }
}
