using AutoMapper;
namespace Brand.Service.Profiles;
public class AutoMapperConfig
{
    public static MapperConfiguration GetMapperConfiguration()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps("Brand.Service");
        });
        return config;
    }
}
