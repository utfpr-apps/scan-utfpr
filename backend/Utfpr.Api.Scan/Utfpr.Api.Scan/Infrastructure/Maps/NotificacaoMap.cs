using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utfpr.Api.Scan.Domain.Models.Notificacao;

namespace Utfpr.Api.Scan.Infrastructure.Maps;

public class NotificacaoMap : BaseEntityConfiguration<Notificacao>
{
    public override void Configure(EntityTypeBuilder<Notificacao> builder)
    {
        base.Configure(builder);
        
        builder
            .Property(a => a.Base64Comprovante)
            .IsRequired();

        builder
            .Property(a => a.DataInicialAfastamento)
            .IsRequired();
        
        builder
            .Property(a => a.DataFinalAfastamento)
            .IsRequired();

        builder
            .HasOne(t => t.Usuario)
            .WithMany(t => t.Notificacoes)
            .HasForeignKey(t => t.UsuarioId);

        builder.ToTable(nameof(Notificacao));
    }
}