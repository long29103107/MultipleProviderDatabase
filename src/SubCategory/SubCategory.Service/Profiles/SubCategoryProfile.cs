using AutoMapper;
using SubCategory.Service.DTO;
using Generate = SubCategory.Model.Generate;
namespace SubCategory.Service.Profiles;
public class SubCategoryProfile : Profile
{
    public SubCategoryProfile()
    {
        ModelToResponse();
        RequestToModel();
    }
    private void RequestToModel()
    {
        CreateMap<SubCategoryCreateRequest, Generate.SubCategory>();
        CreateMap<SubCategoryUpdateRequest, Generate.SubCategory>();
    }
    private void ModelToResponse()
    {
        CreateMap<Generate.SubCategory, SubCategoryReponse>();
    }
}
