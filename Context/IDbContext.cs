
using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using LeakHand.Model;

namespace LeakHand.Context
{
    public interface IDbContext : IDisposable
    {
        DatabaseFacade Database { get; }
        DbSet<Item> Items { get; set; }
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}