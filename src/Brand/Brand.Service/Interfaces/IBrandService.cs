using Brand.Service.DTO;
namespace Brand.Service.Interfaces;
public interface IBrandService : IBaseService
{
    Task<List<BrandReponse>> GetListAsync(ListBrandRequest request);
    Task<BrandReponse> GetDetailAsync(int id);
    Task<BrandReponse> CreateAsync(BrandCreateRequest request);
    Task<BrandReponse> UpdateAsync(int id, BrandUpdateRequest request);
    Task DeleteAsync(int id);
}
