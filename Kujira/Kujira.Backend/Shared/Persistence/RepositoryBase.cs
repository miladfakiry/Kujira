using Kujira.Backend.User.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Shared.Persistence;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : DbItem
{
    protected DbContextBase<T> _dbContext;

    protected RepositoryBase(DbContextBase<T> dbContext)
    {
        _dbContext = dbContext;
    }



    public IEnumerable<T>? GetAll()
    {
        return _dbContext.DbSet;
    }

    public T? Get(Guid id)
    {
        var dbItem = _dbContext.DbSet.Find(id);
        if (dbItem == null)
        {
            throw new KeyNotFoundException();
        }

        return dbItem;
    }

    public void Update(T dbItem)
    {
        if (_dbContext.DbSet == null)
        {
            var test = 1;
        }

        _dbContext.DbSet?.Update(dbItem);
        _dbContext.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var dbItem = Get(id);
        if (dbItem != null)
        {
            _dbContext.DbSet?.Remove(dbItem);
        }
        else
        {
            throw new KeyNotFoundException();
        }

        _dbContext.SaveChanges();
    }

    public void Create(T dbItem)
    {
        _dbContext.DbSet?.Add(dbItem);
        _dbContext.SaveChanges();
    }
}