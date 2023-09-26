using Basket.Repository.BaseWrapper.Interfaces;
namespace Basket.Repository.Interfaces;
public interface IRepositoryWrapper : IRepositoryWrapperBase
{
    IBasketRepository Basket { get; }
}
