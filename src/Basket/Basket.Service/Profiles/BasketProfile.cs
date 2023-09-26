using AutoMapper;
using Basket.Service.DTO;
using Generate = Basket.Model.Generate;
namespace Basket.Service.Profiles;
public class BasketProfile : Profile
{
    public BasketProfile()
    {
        ModelToResponse();
        RequestToModel();
    }
    private void RequestToModel()
    {
        CreateMap<BasketCreateRequest, Generate.Basket>();
        CreateMap<BasketUpdateRequest, Generate.Basket>();
    }
    private void ModelToResponse()
    {
        CreateMap<Generate.Basket, BasketReponse>();
    }
}
