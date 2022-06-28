using Utfpr.Api.Scan.Infrastructure;

namespace Utfpr.Api.Scan.Application.Notificacao.Interfaces;

public interface INotificacaoRepository : IRepository<Domain.Models.Notificacao.Notificacao>
{
    Task<ICollection<Domain.Models.Notificacao.Notificacao>> ObterNotificacoesEmAberto();
    
    Task<ICollection<string>> ObterEmailsContato(Guid notificacaoId);
}