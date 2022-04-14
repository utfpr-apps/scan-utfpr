using MediatR;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application;

public interface ICommand : IRequest<bool>
{
}

public interface ICommand<TResponse> : IRequest<CommandResult<TResponse>>
{
}