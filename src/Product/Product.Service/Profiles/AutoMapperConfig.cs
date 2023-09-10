using AutoMapper;
namespace Product.Service.Profiles;
public class AutoMapperConfig
{
    public static MapperConfiguration GetMapperConfiguration()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps("Product.Service");
        });
        return config;
    }
}
