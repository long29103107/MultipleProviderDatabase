using Basket.Service.DTO;
namespace Basket.Service.Interfaces;
public interface IBasketService : IBaseService
{
    Task<List<BasketReponse>> GetListAsync(ListBasketRequest request);
    Task<BasketReponse> GetDetailAsync(int id);
    Task<BasketReponse> CreateAsync(BasketCreateRequest request);
    Task<BasketReponse> UpdateAsync(int id, BasketUpdateRequest request);
    Task DeleteAsync(int id);
}
