using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utfpr.Api.Scan.Domain.Models.Checkin;

namespace Utfpr.Api.Scan.Infrastructure.Maps;

public class CheckinMap : BaseEntityConfiguration<Checkin>
{
    public override void Configure(EntityTypeBuilder<Checkin> builder)
    {
        base.Configure(builder);
        
        builder
            .Property(a => a.DataCheckin)
            .IsRequired();

        builder
            .Property(a => a.DataFinalizacaoPermanencia)
            .IsRequired();

        builder
            .HasOne(a => a.Ambiente)
            .WithMany(c => c.Checkins)
            .HasForeignKey(f => f.AmbienteId);

        builder
            .HasOne(u => u.Usuario)
            .WithMany(c => c.Checkins)
            .HasForeignKey(u => u.UsuarioId);

        builder.ToTable(nameof(Checkin));
    }
}