using Utfpr.Api.Scan.Application.Notificacao.ViewModels;

namespace Utfpr.Api.Scan.Application.Notificacao.Queries;

public class ObterListaEmailsContatoQuery : Query<ListaEmailContatoNotificacaoViewModel>
{
    public ObterListaEmailsContatoQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}