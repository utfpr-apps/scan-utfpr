using Microsoft.AspNetCore.Authentication.Google;

namespace Utfpr.Api.Scan.Configuration;

public static class AuthenticationConfiguration
{
    public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddGoogle(opt =>
            {
                opt.ClientId = "";
                opt.ClientSecret = "";
            });

        return services;
    }
}