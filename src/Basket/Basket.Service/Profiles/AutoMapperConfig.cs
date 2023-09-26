using AutoMapper;
namespace Basket.Service.Profiles;
public class AutoMapperConfig
{
    public static MapperConfiguration GetMapperConfiguration()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps("Basket.Service");
        });
        return config;
    }
}
