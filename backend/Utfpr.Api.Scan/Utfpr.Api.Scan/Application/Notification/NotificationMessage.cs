using System.Net;

namespace Utfpr.Api.Scan.Application.Notification;

public class NotificationMessage
{
    public NotificationMessage(string? errorMessage)
    {
        ErrorMessage = errorMessage;
    }
    public string? ErrorMessage { get; private set; }
}