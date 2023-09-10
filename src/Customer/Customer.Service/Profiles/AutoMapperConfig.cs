using AutoMapper;
namespace Customer.Service.Profiles;
public class AutoMapperConfig
{
    public static MapperConfiguration GetMapperConfiguration()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps("Customer.Service");
        });
        return config;
    }
}
