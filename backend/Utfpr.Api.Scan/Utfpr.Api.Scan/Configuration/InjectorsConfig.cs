using MediatR;
using Utfpr.Api.Scan.Application.Handlers;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Application.Services;

namespace Utfpr.Api.Scan.Configuration;

public static class InjectorsConfig
{
    public static IServiceCollection AdicionaDependencias(this IServiceCollection services)
    {
        services.AddMediatR(typeof(InjectorsConfig));
        services.AddScoped<INotificationContext, NotificationContext>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IJwtHandler, JwtHandler>();

        return services;
    }
}