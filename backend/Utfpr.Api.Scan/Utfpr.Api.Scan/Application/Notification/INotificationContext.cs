using System.Net;

namespace Utfpr.Api.Scan.Application.Notification;

public interface INotificationContext
{
    bool PossuiNotificacoes { get; }
    IReadOnlyCollection<NotificationMessage> Messages { get; }

    public void AdicionarNotificacoes(HttpStatusCode codigo, string? errorMessage);
}