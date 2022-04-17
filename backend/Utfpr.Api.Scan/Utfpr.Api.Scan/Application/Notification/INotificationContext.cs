using System.Net;

namespace Utfpr.Api.Scan.Application.Notification;

public interface INotificationContext
{
    bool PossuiNotificacoes { get; }
    HttpStatusCode Code { get; set; }
    IReadOnlyCollection<NotificationMessage> Messages { get; }

    public void AdicionarNotificacoes(HttpStatusCode code, string? errorMessage);
}