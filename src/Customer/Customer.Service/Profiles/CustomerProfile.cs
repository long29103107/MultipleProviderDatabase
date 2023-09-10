using AutoMapper;
using Customer.Service.DTO;
using Generate = Customer.Model.Generate;
namespace Customer.Service.Profiles;
public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        ModelToResponse();
        RequestToModel();
    }
    private void RequestToModel()
    {
        CreateMap<CustomerCreateRequest, Generate.Customer>();
        CreateMap<CustomerUpdateRequest, Generate.Customer>();
    }
    private void ModelToResponse()
    {
        CreateMap<Generate.Customer, CustomerReponse>();
    }
}
