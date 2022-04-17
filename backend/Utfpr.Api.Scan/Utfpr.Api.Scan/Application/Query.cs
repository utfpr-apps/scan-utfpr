using MediatR;

namespace Utfpr.Api.Scan.Application;

public abstract class Query<TViewModel> : IRequest<TViewModel>
{
    
}