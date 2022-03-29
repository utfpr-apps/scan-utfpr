using Microsoft.AspNetCore.Authentication.Google;

namespace Utfpr.Api.Scan.Configuration;

public static class AuthenticationConfiguration
{
    public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services)
    {
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
        });

        return services;
    }
}