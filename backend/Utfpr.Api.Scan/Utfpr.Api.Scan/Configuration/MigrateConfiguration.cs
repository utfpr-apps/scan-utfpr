using Microsoft.EntityFrameworkCore;

namespace Utfpr.Api.Scan.Configuration;

public static class MigrateConfiguration
{
    public static WebApplication MigrateDatabase<T>(this WebApplication app) where T : DbContext
    {
        using(var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var db = services.GetRequiredService<T>();
                db.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
        return app;
    }
}