using Microsoft.OpenApi.Models;
using Utfpr.Api.Scan.Configuration;
using Utfpr.Api.Scan.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

builder.Configuration.AddConfiguration(configurationBuilder.Build());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "API Scan UTFPR", Version = "v1"});

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});
builder.Services.ConfigureDatabase(builder.Configuration, builder.Environment);
builder.Services.AddAuthenticationConfiguration();
builder.Services.AddControllers();
builder.Services.AdicionaDependencias();
builder.Services.AdicionaCors();
builder.Services.AddProfilesConfiguration();

var app = builder.Build();

//app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization(); 
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSwagger();
app.UseSwaggerUI();

app.ConfiguraCors();
await app.MigrateDatabase<ApplicationDbContext>();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    await serviceProvider.CriaEstruturaUsuarios();
}


app.Run();