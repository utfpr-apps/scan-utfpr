using System.Net;

namespace Utfpr.Api.Scan.Application.Notification;

public class NotificationMessage
{
    public NotificationMessage(HttpStatusCode codigo, string? errorMessage)
    {
        Codigo = codigo;
        ErrorMessage = errorMessage;
    }

    public HttpStatusCode Codigo { get; private set; }
    public string? ErrorMessage { get; private set; }
}