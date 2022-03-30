using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utfpr.Api.Scan.Domain.Models.Ambientes;

namespace Utfpr.Api.Scan.Infrastructure.Maps;

public class AmbienteMap : BaseEntityConfiguration<Ambiente>
{
    public override void Configure(EntityTypeBuilder<Ambiente> builder)
    {
        base.Configure(builder);
        
        builder
            .Property(a => a.CodigoSala)
            .IsRequired();

        builder
            .Property(a => a.TamanhoBloco)
            .IsRequired();

        builder.ToTable(nameof(Ambiente));
    }
}