using Utfpr.Api.Scan.Application.Checkin.Interfaces;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Domain.Models.Checkin;
using Utfpr.Api.Scan.Infrastructure.Data;

namespace Utfpr.Api.Scan.Infrastructure.Repositories;

public class CheckinRepository : Repository<Checkin>, ICheckinRepository
{
    public CheckinRepository(ApplicationDbContext context, INotificationContext notificationContext) : base(context, notificationContext)
    {
    }
}