using Brand.Repository.BaseWrapper.Interfaces;
namespace Brand.Repository.Interfaces;
public interface IRepositoryWrapper : IRepositoryWrapperBase
{
    IBrandRepository Brand { get; }
}
