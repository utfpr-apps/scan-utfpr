namespace Utfpr.Api.Scan.Configuration;

public static class CorsConfiguration
{
    public static void AdicionaCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("EnableCORS", builder =>
            {
                builder.WithOrigins().AllowAnyMethod().AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials().Build();
            });
        });
    }

    public static void ConfiguraCors(this WebApplication app)
    {
        app.UseCors("EnableCORS");
    }
}