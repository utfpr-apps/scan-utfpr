using Utfpr.Api.Scan.Domain.Enumeradores;

namespace Utfpr.Api.Scan.Application.Notificacao.ViewModels;

public class NotificacaoViewModel : BaseViewModel
{
    public Guid Id { get; set; }
    public DateTime DataCadastro { get; set; }
    public string Base64Comprovante { get; set; }
    public DateTime DataInicialAfastamento { get; set; }
    public DateTime DataFinalAfastamento { get; set; }
    public string UsuarioId { get; set; }
    public string UsuarioNome { get; set; }
    public StatusNotificacaoEnum Status { get; set; }
}