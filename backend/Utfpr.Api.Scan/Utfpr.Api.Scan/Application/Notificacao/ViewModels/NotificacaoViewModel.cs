namespace Utfpr.Api.Scan.Application.Notificacao.ViewModels;

public class NotificacaoViewModel : BaseViewModel
{
    public Guid Id { get; set; }
    public DateTime DataCadastro { get; set; }
    public string Base64Comprovante { get; set; }
    public DateTime DataInicialAfastamento { get; set; }
    public DateTime DataFinalAfastamento { get; set; }
    public string UsuarioId { get; set; }
}