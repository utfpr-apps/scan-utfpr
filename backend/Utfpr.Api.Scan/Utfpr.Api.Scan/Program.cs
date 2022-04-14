using Utfpr.Api.Scan.Configuration;
using Utfpr.Api.Scan.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.AddAuthenticationConfiguration();
builder.Services.AdicionaDependencias();
builder.Services.AdicionaCors();
builder.Services.AddProfilesConfiguration();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.ConfiguraCors();
app.MigrateDatabase<ApplicationDbContext>();

app.Run();