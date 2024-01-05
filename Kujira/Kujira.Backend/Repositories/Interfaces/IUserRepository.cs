﻿using Kujira.Backend.Models;
using Kujira.Backend.Shared;

namespace Kujira.Backend.Repositories.Interfaces;

public interface IUserRepository : IRepositoryBase<User>
{
    Task<User?> GetByIdAsync(Guid id);
}