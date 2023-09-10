using AutoMapper;
using Product.Service.DTO;
using Generate = Product.Model.Generate;
namespace Product.Service.Profiles;
public class ProductProfile : Profile
{
    public ProductProfile()
    {
        ModelToResponse();
        RequestToModel();
    }
    private void RequestToModel()
    {
        CreateMap<ProductCreateRequest, Generate.Product>();
        CreateMap<ProductUpdateRequest, Generate.Product>();
    }
    private void ModelToResponse()
    {
        CreateMap<Generate.Product, ProductReponse>();
    }
}
