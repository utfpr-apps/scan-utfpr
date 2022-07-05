using Utfpr.Api.Scan.Domain.Models.Autenticacao;

namespace Utfpr.Api.Scan.Domain.Models.Notificacao;

public class Notificacao : Entity
{
    public string Base64Comprovante { get; set; }
    public DateTime DataInicialAfastamento { get; set; }
    public DateTime DataFinalAfastamento { get; set; }
    
    public string? UsuarioId { get; set; }
    public virtual ApplicationUser Usuario { get; set; }

    public Notificacao() { }

    public Notificacao(DateTime dataInicialAfastamento, DateTime dataFinalAfastamento, string? usuarioId, string base64Comprovante)
    {
        DataInicialAfastamento = dataInicialAfastamento;
        DataFinalAfastamento = dataFinalAfastamento;
        UsuarioId = usuarioId;
        Base64Comprovante = base64Comprovante;
    }
}