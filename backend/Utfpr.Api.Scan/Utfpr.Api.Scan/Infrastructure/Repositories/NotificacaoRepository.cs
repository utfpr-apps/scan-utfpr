using Microsoft.EntityFrameworkCore;
using Utfpr.Api.Scan.Application.Notificacao.Interfaces;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Domain.Models.Checkin;
using Utfpr.Api.Scan.Domain.Models.Notificacao;
using Utfpr.Api.Scan.Infrastructure.Data;

namespace Utfpr.Api.Scan.Infrastructure.Repositories;

public class NotificacaoRepository : Repository<Notificacao>, INotificacaoRepository
{
    public NotificacaoRepository(ApplicationDbContext context, INotificationContext notificationContext) : base(context,
        notificationContext)
    {
    }

    public async Task<ICollection<Notificacao>> ObterNotificacoesEmAberto()
    {
        return await DbSet
            .AsQueryable()
            .AsNoTracking()
            .Include(t => t.Usuario)
            .Where(t => t.DataFinalAfastamento > DateTime.UtcNow)
            .ToListAsync();
    }

    public async Task<ICollection<string>> ObterEmailsContato(Guid notificacaoId)
    {
        var notificacao = await DbSet
            .AsQueryable()
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == notificacaoId);

        //checkins aluno positivo
        var checkins = await DbSet
            .AsQueryable()
            .AsNoTracking()
            .Include(t => t.Usuario)
            .ThenInclude(t => t.Checkins)
            .Where(t => t.Usuario.Checkins.Any(j => notificacao != null &&
                                                    j.UsuarioId == notificacao.UsuarioId &&
                                                    j.DataCheckin >= t.DataInicialAfastamento.AddDays(-7) &&
                                                    j.DataCheckin <= t.DataFinalAfastamento))
            .Select(t => t.Usuario.Checkins)
            .FirstOrDefaultAsync();

        if (checkins == null)
            return new List<string>();

        //checkins de alunos que tiveram contato
        return await Context.Checkins
            .AsQueryable()
            .AsNoTracking()
            .Include(t => t.Usuario)
            .Where(contato => checkins.Any(positivo => positivo.Ambiente == contato.Ambiente &&
                                                       contato.DataCheckin <= positivo.DataFinalizacaoPermanencia &&
                                                       contato.DataCheckin >= positivo.DataCheckin))
            .Select(contato => contato.Usuario.Email)
            .ToListAsync();
    }
}