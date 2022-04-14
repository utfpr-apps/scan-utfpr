using AutoMapper;
using Utfpr.Api.Scan.Application.Ambiente;

namespace Utfpr.Api.Scan.Configuration;

public static class ProfilesConfiguration
{
    public static void AddProfilesConfiguration(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AmbienteProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}