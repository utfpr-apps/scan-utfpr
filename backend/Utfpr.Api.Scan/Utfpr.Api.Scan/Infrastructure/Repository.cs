using System.Net;
using Microsoft.EntityFrameworkCore;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Domain.Models;
using Utfpr.Api.Scan.Infrastructure.Data;

namespace Utfpr.Api.Scan.Infrastructure;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly DbSet<T> _dbSet;
    private readonly ApplicationDbContext _context;
    private readonly INotificationContext _notificationContext;

    public Repository(ApplicationDbContext context, INotificationContext notificationContext)
    {
        _context = context;
        _notificationContext = notificationContext;
        _dbSet = context.Set<T>();
    }

    public async Task<bool> Adicionar(T entity)
    {
        await _dbSet.AddAsync(entity);

        if (await Commit())
            return true;
        
        _notificationContext.AdicionarNotificacoes(HttpStatusCode.InternalServerError, 
            Mensagens.ErroAoSalvarOperacao);
        return false;
    }

    public async Task<bool> Deletar(Guid id)
    {
        var registro = await _dbSet.FirstOrDefaultAsync(t => t.Id.Equals(id));
        if (registro == null)
        {
            _notificationContext.AdicionarNotificacoes(HttpStatusCode.NotFound, Mensagens.RegistroNaoEncontrado);
            return false;
        }
        
        _dbSet.Remove(registro);
        if (await Commit())
            return true;
        
        _notificationContext.AdicionarNotificacoes(HttpStatusCode.InternalServerError, 
            Mensagens.ErroAoSalvarOperacao);
        return false;
    }

    public async Task<bool> Atualizar(T entity)
    {
        _dbSet.Update(entity);
        if (await Commit())
            return true;
        
        _notificationContext.AdicionarNotificacoes(HttpStatusCode.InternalServerError, 
            Mensagens.ErroAoSalvarOperacao);
        return false;
    }

    public async Task<T?> ObterPorId(Guid id)
    {
        var registro = await _dbSet.FirstOrDefaultAsync(t => t.Id.Equals(id));
        if (registro != null)
            return registro;
        
        _notificationContext.AdicionarNotificacoes(HttpStatusCode.NotFound, Mensagens.RegistroNaoEncontrado);
        return null;
    }

    public async Task<ICollection<T>> ObterTodos()
    {
        return await _dbSet
            .AsQueryable()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> Commit()
    {
        return !(await _context.SaveChangesAsync() < 1);
    }

    public async Task<bool> Existe(Guid id)
    {
        return await _dbSet
            .Where(i => i.Id.Equals(id))
            .AnyAsync();
    }
}