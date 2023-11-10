using SubCategory.Service.DTO;
namespace SubCategory.Service.Interfaces;
public interface ISubCategoryService : IBaseService
{
    Task<List<SubCategoryReponse>> GetListAsync(ListSubCategoryRequest request);
    Task<SubCategoryReponse> GetDetailAsync(int id);
    Task<SubCategoryReponse> CreateAsync(SubCategoryCreateRequest request);
    Task<SubCategoryReponse> UpdateAsync(int id, SubCategoryUpdateRequest request);
    Task DeleteAsync(int id);
}
