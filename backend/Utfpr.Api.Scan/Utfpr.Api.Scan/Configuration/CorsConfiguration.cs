namespace Utfpr.Api.Scan.Configuration;

public static class CorsConfiguration
{
    public static void AdicionaCors(this IServiceCollection services)
    {
        services.AddCors();
    }

    public static void ConfiguraCors(this WebApplication app)
    {
        app.UseCors(x =>
            x.AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());
    }
}