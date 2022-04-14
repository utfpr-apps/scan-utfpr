using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utfpr.Api.Scan.Domain.Models;
using Utfpr.Api.Scan.Domain.Models.Ambientes;

namespace Utfpr.Api.Scan.Infrastructure.Maps;

public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.CadastradoEm)
            .HasDefaultValueSql("NOW()");
    }
}