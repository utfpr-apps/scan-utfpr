using System.Net;

namespace Utfpr.Api.Scan.Application.Notification;

public class NotificationContext : INotificationContext
{
    private readonly List<NotificationMessage> _messages;
    public bool PossuiNotificacoes => _messages.Any() ;
    public HttpStatusCode Code { get; set; }
    public IReadOnlyCollection<NotificationMessage> Messages => _messages;

    public NotificationContext()
    {
        _messages = new List<NotificationMessage>();
    }
    
    public void AdicionarNotificacoes(HttpStatusCode code, string? errorMessage)
    {
        Code = code;
        _messages.Add(new NotificationMessage(errorMessage));
    }
    
    
}