using MediatR;
using Utfpr.Api.Scan.Application.Ambiente.Interfaces;
using Utfpr.Api.Scan.Application.Checkin.Interfaces;
using Utfpr.Api.Scan.Application.Handlers;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Application.Services;
using Utfpr.Api.Scan.Infrastructure.Repositories;

namespace Utfpr.Api.Scan.Configuration;

public static class InjectorsConfig
{
    public static IServiceCollection AdicionaDependencias(this IServiceCollection services)
    {
        services.AddMediatR(typeof(InjectorsConfig));
        services.AddScoped<INotificationContext, NotificationContext>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IJwtHandler, JwtHandler>();
        services.AddScoped<IAmbienteRepository, AmbienteRepository>();
        services.AddScoped<ICheckinRepository, CheckinRepository>();

        return services;
    }
}