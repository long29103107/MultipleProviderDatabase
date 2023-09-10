using Shared.Repository.RepositoryBase.Interfaces;
using Generate = Product.Model.Generate;

namespace Product.Repository.Interfaces;
public interface IProductRepository : IRepositoryBase<Generate.Product>
{
}
