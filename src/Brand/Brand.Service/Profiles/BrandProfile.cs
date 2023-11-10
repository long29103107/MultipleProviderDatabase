using AutoMapper;
using Brand.Service.DTO;
using Generate = Brand.Model.Generate;
namespace Brand.Service.Profiles;
public class BrandProfile : Profile
{
    public BrandProfile()
    {
        ModelToResponse();
        RequestToModel();
    }
    private void RequestToModel()
    {
        CreateMap<BrandCreateRequest, Generate.Brand>();
        CreateMap<BrandUpdateRequest, Generate.Brand>();
    }
    private void ModelToResponse()
    {
        CreateMap<Generate.Brand, BrandReponse>();
    }
}
