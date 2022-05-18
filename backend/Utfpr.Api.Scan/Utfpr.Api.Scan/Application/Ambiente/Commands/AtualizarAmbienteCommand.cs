using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Utfpr.Api.Scan.Application.Ambiente.ViewModels;

namespace Utfpr.Api.Scan.Application.Ambiente.Commands;

public class AtualizarAmbienteCommand : Command<AmbienteViewModel>
{
    [JsonIgnore] 
    public Guid Id { get; private set; }

    public byte TamanhoBloco { get; set; }
    public string CodigoSala { get; set; }

    public AtualizarAmbienteCommand AtribuirAmbienteId(Guid id)
    {
        Id = id;
        return this;
    }
}