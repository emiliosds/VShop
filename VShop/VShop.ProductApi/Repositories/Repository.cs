﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly AppDbContext _context;

    protected Repository(AppDbContext context)
    {
        _dbSet = context.Set<TEntity>();
        _context = context;
    }

    public async Task Add(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var entity = await GetById(id);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter = null)
    {
        var query = _dbSet.AsQueryable();

        if(filter != null)
            query = query.Where(filter)
                .AsNoTracking();

        return await query.ToListAsync();
    }
}