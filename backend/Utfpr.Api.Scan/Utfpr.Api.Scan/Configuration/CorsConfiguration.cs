namespace Utfpr.Api.Scan.Configuration;

public static class CorsConfiguration
{
    public static void AdicionaCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true));
        });
    }

    public static void ConfiguraCors(this WebApplication app)
    {
        app.UseCors("AllowAnyOrigin");
    }
}