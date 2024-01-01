
namespace Kujira.Backend.Shared;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : DbItem
{
    protected KujiraContext DbContext;

    protected RepositoryBase(KujiraContext dbContext)
    {
        DbContext = dbContext;
    }

    public IEnumerable<T>? GetAll()
    {
        return DbContext.Set<T>().ToList();
    }

    public T? Get(Guid id)
    {
        var dbItem = DbContext.Set<T>().Find(id);
        if (dbItem == null)
        {
            throw new KeyNotFoundException();
        }

        return dbItem;
    }

    public void Update(T dbItem)
    {
        DbContext.Set<T>()?.Update(dbItem);
        DbContext.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var dbItem = Get(id);
        if (dbItem != null)
        {
            DbContext.Set<T>()?.Remove(dbItem);
            DbContext.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException();
        }


    }

    public void Create(T dbItem)
    {
        DbContext.Set<T>()?.Add(dbItem);
        DbContext.SaveChanges();
    }
}