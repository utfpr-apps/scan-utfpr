using System.Net;
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Application;

public class ErrorObjectMessage
{
    public HttpStatusCode StatusCode { get; set; }
    public IReadOnlyCollection<NotificationMessage> Messages { get; set; }

    public ErrorObjectMessage(HttpStatusCode statusCode, IReadOnlyCollection<NotificationMessage> messages)
    {
        StatusCode = statusCode;
        Messages = messages;
    }
}