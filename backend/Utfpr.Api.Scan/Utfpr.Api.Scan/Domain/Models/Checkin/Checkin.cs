using Utfpr.Api.Scan.Domain.Models.Ambientes;

namespace Utfpr.Api.Scan.Domain.Models.Checkin;

public class Checkin : Entity
{
    public DateTime DataCheckin { get; set; }
    public DateTime DataFinalizacaoPermanencia { get; set; }
    public Guid AmbienteId { get; set; }

    public virtual Ambiente Ambiente { get; set; }

    public Checkin() { }

    public Checkin(DateTime dataCheckin, DateTime dataFinalizacaoPermanencia, Guid ambienteId)
    {
        DataCheckin = dataCheckin;
        DataFinalizacaoPermanencia = dataFinalizacaoPermanencia;
        AmbienteId = ambienteId;
    }
}