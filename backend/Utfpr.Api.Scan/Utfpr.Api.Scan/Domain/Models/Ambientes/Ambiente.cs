namespace Utfpr.Api.Scan.Domain.Models.Ambientes;

public class Ambiente : Entity
{
    public string CodigoSala { get; set; }
    public byte TamanhoBloco { get; set; }
    public virtual ICollection<Checkin.Checkin> Checkins { get; set; }

    public Ambiente() { }

    public Ambiente(Guid id, string codigoSala, byte tamanhoBloco)
    {
        Id = id;
        CodigoSala = codigoSala;
        TamanhoBloco = tamanhoBloco;
    }
}