﻿using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.User.Domain;

public class Role : DbItem
{
    public Role(Guid id, string name) : base(id)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; set; }
}