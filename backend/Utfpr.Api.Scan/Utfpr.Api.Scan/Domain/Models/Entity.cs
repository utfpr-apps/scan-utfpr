namespace Utfpr.Api.Scan.Domain.Models;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CadastradoEm { get; set; }
}