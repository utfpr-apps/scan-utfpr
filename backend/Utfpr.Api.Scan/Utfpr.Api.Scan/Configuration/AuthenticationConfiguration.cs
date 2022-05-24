using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Utfpr.Api.Scan.Configuration;

public static class AuthenticationConfiguration
{
    public static void AddAuthenticationConfiguration(this IServiceCollection services)
    {
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
        });
    }
}