using AutoMapper;
using Utfpr.Api.Scan.Application.Ambiente;
using Utfpr.Api.Scan.Application.Autenticacao;
using Utfpr.Api.Scan.Application.Notificacao;

namespace Utfpr.Api.Scan.Configuration;

public static class ProfilesConfiguration
{
    public static void AddProfilesConfiguration(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AmbienteProfile());
            mc.AddProfile(new UsuariosAutoMapper());
            mc.AddProfile(new NotificacaoAutoMapper());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}