using Utfpr.Api.Scan.Domain.Models.Ambientes;
using Utfpr.Api.Scan.Domain.Models.Autenticacao;

namespace Utfpr.Api.Scan.Domain.Models.Checkin;

public class Checkin : Entity
{
    public DateTime DataCheckin { get; set; }
    public DateTime DataFinalizacaoPermanencia { get; set; }
    public Guid AmbienteId { get; set; }
    public string UsuarioId { get; set; }

    public virtual Ambiente Ambiente { get; set; }
    public virtual ApplicationUser Usuario { get; set; }

    public Checkin() { }

    public Checkin(DateTime dataCheckin, DateTime dataFinalizacaoPermanencia, Guid ambienteId)
    {
        DataCheckin = dataCheckin;
        DataFinalizacaoPermanencia = dataFinalizacaoPermanencia;
        AmbienteId = ambienteId;
    }
}