using AutoMapper;
namespace Category.Service.Profiles;
public class AutoMapperConfig
{
    public static MapperConfiguration GetMapperConfiguration()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps("Category.Service");
        });
        return config;
    }
}
