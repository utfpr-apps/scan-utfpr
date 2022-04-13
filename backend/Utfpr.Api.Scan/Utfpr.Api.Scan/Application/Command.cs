using MediatR;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application;

public abstract class Command : ICommand
{
}

public abstract class Command<TResponse> : ICommand<TResponse>
{
}