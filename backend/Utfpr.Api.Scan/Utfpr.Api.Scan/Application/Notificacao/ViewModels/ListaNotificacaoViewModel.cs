namespace Utfpr.Api.Scan.Application.Notificacao.ViewModels;

public class ListaNotificacaoViewModel : BaseViewModel
{
    public ICollection<NotificacaoViewModel> Notificacoes { get; set; }
    public int CasosEncerrados { get; set; }
    public int CasosAbertos { get; set; }
    public int Total { get; set; }
}