﻿using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;
using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.Repositories;

public class RequestRepository : RepositoryBase<Request>, IRequestRepository
{
    public RequestRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(Request dbItem)
    {
        throw new NotImplementedException();
    }

    public void Update(Request dbItem)
    {
        throw new NotImplementedException();
    }

    Request? IRepositoryBase<Request>.Get(Guid id)
    {
        throw new NotImplementedException();
    }

    IEnumerable<Request>? IRepositoryBase<Request>.GetAll()
    {
        throw new NotImplementedException();
    }
}