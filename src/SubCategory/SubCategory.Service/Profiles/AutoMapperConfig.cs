using AutoMapper;
namespace SubCategory.Service.Profiles;
public class AutoMapperConfig
{
    public static MapperConfiguration GetMapperConfiguration()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps("SubCategory.Service");
        });
        return config;
    }
}
