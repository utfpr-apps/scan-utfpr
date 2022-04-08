
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Domain.Models
{
    public class CommandResult<TResponse>
    {
        private static CommandResult<TResponse> DefaultFailed = new CommandResult<TResponse>(null,false);
        
        public bool IsSuccess { get; set; }
        public TResponse Result { get; set; }
        public IReadOnlyCollection<NotificationMessage> Messages => _messages;
        
        private List<NotificationMessage> _messages = new List<NotificationMessage>();

        public CommandResult(IReadOnlyCollection<NotificationMessage> message = null, bool isSuccess = false)
        {
            IsSuccess = isSuccess;
            _messages.AddRange(message);
        }

        public CommandResult(bool isSuccess, TResponse result)
        {
            IsSuccess = isSuccess;
            Result = result;
        }

        public void Deconstruct(out bool isSuccess, out TResponse result)
        {
            isSuccess = IsSuccess;
            result = Result;
        }

        public static CommandResult<TResponse> CreateFailedResult()
        {
            return DefaultFailed;
        }
        
        public static CommandResult<TResponse> CreateSuccessResult(TResponse body)
        {
            return new CommandResult<TResponse>(true, body);
        }
    }
}