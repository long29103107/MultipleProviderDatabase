using Category.Service.DTO;
namespace Category.Service.Interfaces;
public interface ICategoryService : IBaseService
{
    Task<List<CategoryReponse>> GetListAsync(ListCategoryRequest request);
    Task<CategoryReponse> GetDetailAsync(int id);
    Task<CategoryReponse> CreateAsync(CategoryCreateRequest request);
    Task<CategoryReponse> UpdateAsync(int id, CategoryUpdateRequest request);
    Task DeleteAsync(int id);
}
