﻿
namespace Kujira.Backend.Shared;

public interface IRepositoryBase<T> where T : class
{

    IEnumerable<T>? GetAll();

    T? Get(Guid id);

    void Create(T dbItem);

    void Update(T dbItem);

    void Delete(Guid id);

}