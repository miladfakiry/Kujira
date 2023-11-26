using Kujira.Backend.User.Persistence;

namespace Kujira.Backend.Shared.Persistence;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : DbItem
{
    protected KujiraContext _dbContext;

    protected RepositoryBase(KujiraContext dbContext)
    {
        _dbContext = dbContext;
    }


    public IEnumerable<T>? GetAll()
    {
        return _dbContext.Set<T>().ToList();
    }

    public T? Get(Guid id)
    {
        var dbItem = _dbContext.Set<T>().Find(id);
        if (dbItem == null)
        {
            throw new KeyNotFoundException();
        }

        return dbItem;
    }

    public void Update(T dbItem)
    {
        _dbContext.Set<T>()?.Update(dbItem);
        _dbContext.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var dbItem = Get(id);
        if (dbItem != null)
        {
            _dbContext.Set<T>()?.Remove(dbItem);
            _dbContext.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException();
        }

        
    }

    public void Create(T dbItem)
    {
        _dbContext.Set<T>()?.Add(dbItem);
        _dbContext.SaveChanges();
    }
}