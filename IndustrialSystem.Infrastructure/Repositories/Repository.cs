using IndustrialSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IndustrialSystem.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<T> Set;

    public Repository(AppDbContext context)
    {
        Context = context;
        Set = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
        => await Set.ToListAsync();

    public async Task<T?> GetByIdAsync(int id)
        => await Set.FindAsync(id);

    public async Task AddAsync(T entity)
        => await Set.AddAsync(entity);

    public void Remove(T entity)
        => Set.Remove(entity);

    public async Task SaveChangesAsync()
        => await Context.SaveChangesAsync();
}
