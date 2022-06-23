using System.Text.Json.Serialization;
using Utfpr.Api.Scan.Application.Notificacao.ViewModels;

namespace Utfpr.Api.Scan.Application.Notificacao.Commands;

public class CadastrarNotificacaoCommand : Command<NotificacaoViewModel>
{
    public CadastrarNotificacaoCommand()
    {
        Id = Guid.NewGuid();
    }

    [JsonIgnore]
    public Guid Id { get; private set; }
    public string Imagem { get; set; }
    public DateTime DataInicialAfastamento { get; set; }
    public DateTime DataFinalAfastamento { get; set; }
    [JsonIgnore]
    public string UsuarioId { get; set; }
    
    public CadastrarNotificacaoCommand AtribuirUsuarioId(string usuarioId)
    {
        UsuarioId = usuarioId;
        return this;
    }
}