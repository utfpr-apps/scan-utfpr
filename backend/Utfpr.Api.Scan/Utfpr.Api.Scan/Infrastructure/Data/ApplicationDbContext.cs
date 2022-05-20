using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Utfpr.Api.Scan.Domain.Models.Ambientes;
using Utfpr.Api.Scan.Domain.Models.Autenticacao;
using Utfpr.Api.Scan.Domain.Models.Checkin;

namespace Utfpr.Api.Scan.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Ambiente> Ambientes { get; set; }
    public DbSet<Checkin> Checkins { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}