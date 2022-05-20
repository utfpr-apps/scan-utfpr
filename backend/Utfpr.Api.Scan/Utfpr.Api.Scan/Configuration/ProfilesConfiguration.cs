using AutoMapper;
using Utfpr.Api.Scan.Application.Ambiente;
using Utfpr.Api.Scan.Application.Autenticacao;

namespace Utfpr.Api.Scan.Configuration;

public static class ProfilesConfiguration
{
    public static void AddProfilesConfiguration(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AmbienteProfile());
            mc.AddProfile(new UsuariosAutoMapper());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}