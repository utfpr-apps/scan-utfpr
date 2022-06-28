using System.Net;
using Microsoft.EntityFrameworkCore;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Domain.Models;
using Utfpr.Api.Scan.Infrastructure.Data;

namespace Utfpr.Api.Scan.Infrastructure;

public class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly DbSet<T> DbSet;
    protected readonly ApplicationDbContext Context;
    private readonly INotificationContext _notificationContext;

    public Repository(ApplicationDbContext context, INotificationContext notificationContext)
    {
        Context = context;
        _notificationContext = notificationContext;
        DbSet = context.Set<T>();
    }

    public async Task<bool> Adicionar(T entity)
    {
        await DbSet.AddAsync(entity);

        if (await Commit())
            return true;
        
        _notificationContext.AdicionarNotificacoes(HttpStatusCode.InternalServerError, 
            Mensagens.ErroAoSalvarOperacao);
        return false;
    }

    public async Task<bool> Deletar(Guid id)
    {
        var registro = await DbSet.FirstOrDefaultAsync(t => t.Id.Equals(id));
        if (registro == null)
        {
            _notificationContext.AdicionarNotificacoes(HttpStatusCode.NotFound, Mensagens.RegistroNaoEncontrado);
            return false;
        }
        
        DbSet.Remove(registro);
        if (await Commit())
            return true;
        
        _notificationContext.AdicionarNotificacoes(HttpStatusCode.InternalServerError, 
            Mensagens.ErroAoSalvarOperacao);
        return false;
    }

    public async Task<bool> Atualizar(T entity)
    {
        DbSet.Update(entity);
        if (await Commit())
            return true;
        
        _notificationContext.AdicionarNotificacoes(HttpStatusCode.InternalServerError, 
            Mensagens.ErroAoSalvarOperacao);
        return false;
    }

    public async Task<T?> ObterPorId(Guid id)
    {
        var registro = await DbSet.FirstOrDefaultAsync(t => t.Id.Equals(id));
        if (registro != null)
            return registro;
        
        return null;
    }

    public async Task<ICollection<T>> ObterTodos()
    {
        return await DbSet
            .AsQueryable()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> Commit()
    {
        return !(await Context.SaveChangesAsync() < 1);
    }

    public async Task<bool> Existe(Guid id)
    {
        return await DbSet
            .Where(i => i.Id.Equals(id))
            .AnyAsync();
    }
}