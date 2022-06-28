namespace Utfpr.Api.Scan.Application.Notificacao.ViewModels;

public class ListaEmailContatoNotificacaoViewModel : BaseViewModel
{
    public ICollection<string> Emails { get; set; }
}