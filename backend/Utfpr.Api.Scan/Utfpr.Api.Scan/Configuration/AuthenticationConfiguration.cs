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
                opt.ClientId = "738097913258-9bk5qctc07ahta2kncaqv702qns9v2br.apps.googleusercontent.com";
                opt.ClientSecret = "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";
            });

        return services;
    }
}