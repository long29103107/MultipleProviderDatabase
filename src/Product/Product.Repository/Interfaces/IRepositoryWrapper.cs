using Product.Repository.Interfaces;
using Shared.Repository.WrapperBase.Interfaces;
namespace Product.Repository.Interfaces;
public interface IRepositoryWrapper : IRepositoryWrapperBase
{
    IProductRepository Product { get; }
}
