using Utfpr.Api.Scan.Application.Ambiente.Interfaces;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Domain.Models.Ambientes;
using Utfpr.Api.Scan.Infrastructure.Data;

namespace Utfpr.Api.Scan.Infrastructure.Repositories;

public class AmbienteRepository : Repository<Ambiente>, IAmbienteRepository
{
    public AmbienteRepository(ApplicationDbContext context, INotificationContext notificationContext) : base(context, notificationContext)
    {
    }
}