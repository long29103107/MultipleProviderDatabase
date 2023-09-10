using AutoMapper;
using Category.Service.DTO;
using Generate = Category.Model.Generate;
namespace Category.Service.Profiles;
public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        ModelToResponse();
        RequestToModel();
    }
    private void RequestToModel()
    {
        CreateMap<CategoryCreateRequest, Generate.Category>();
        CreateMap<CategoryUpdateRequest, Generate.Category>();
    }
    private void ModelToResponse()
    {
        CreateMap<Generate.Category, CategoryReponse>();
    }
}
