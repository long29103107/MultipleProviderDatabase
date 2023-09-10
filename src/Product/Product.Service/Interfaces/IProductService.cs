using Product.Service.DTO;
namespace Product.Service.Interfaces;
public interface IProductService : IBaseService
{
    Task<List<ProductReponse>> GetListAsync(ListProductRequest request);
    Task<ProductReponse> GetDetailAsync(int id);
    Task<ProductReponse> CreateAsync(ProductCreateRequest request);
    Task<ProductReponse> UpdateAsync(int id, ProductUpdateRequest request);
    Task DeleteAsync(int id);
}
