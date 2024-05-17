using Microsoft.EntityFrameworkCore;
using System.Data.Common;

using PizzaShopManagerApi.Models;

namespace PizzaShopManagerApi.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : ModelBase
{
    public Task<IList<TEntity>> GetAll();
    public Task<TEntity> GetById(int id);
    public Task<TEntity> Add(TEntity entity);
    public Task Update(TEntity entity);
    public Task Delete(int id);
}

public abstract class RepositoryBase<TEntity>
    : IRepositoryBase<TEntity> where TEntity : ModelBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public RepositoryBase(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext ??
            throw new ArgumentNullException(nameof(applicationDbContext));
    }

    public virtual async Task<IList<TEntity>> GetAll()
    {
        try
        {
            var data = await _applicationDbContext.Set<TEntity>().ToListAsync();

            return data;
        }
        catch (DbException ex)
        {
            throw new RepositoryException(
                "Unable to retrieve entries from the database.", ex);
        }
    }

    public virtual async Task<TEntity> GetById(int id)
    {
        try
        {
            var data = await _applicationDbContext.Set<TEntity>().FindAsync(id)
                ?? throw new RepositoryException("Entity is not found.");

            return data;
        }
        catch (DbException ex)
        {
            throw new RepositoryException(
                $"Unable to retrieve entry with ID: {id}", ex);
        }
    }

    public virtual async Task<TEntity> Add(TEntity entity)
    {
        try
        {
            entity.Id = _applicationDbContext.Set<TEntity>().Count() + 1;

            await _applicationDbContext.Set<TEntity>().AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
            return entity;
        }
        catch (DbUpdateException ex)
        {
            throw new RepositoryException(
                "Error occurred while adding entity.", ex);
        }
    }

    public virtual async Task Update(TEntity entity)
    {
        try
        {
            entity.UpdatedOn = DateTime.UtcNow; // TODO: Update Only on Successful Change

            _applicationDbContext.Attach(entity);
            _applicationDbContext.Entry(entity).State = EntityState.Modified;

            await _applicationDbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new RepositoryException(
                "Error occurred while updating because a concurrency " +
                "conflict was detected.", ex);
        }
        catch (DbUpdateException ex)
        {
            throw new RepositoryException(
                "Error occurred while updating entity.", ex);
        }
    }

    public virtual async Task Delete(int id)
    {
        try
        {
            _applicationDbContext.Set<TEntity>().Remove(await GetById(id));
            await _applicationDbContext.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new RepositoryException(
                "Error occurred while deleting entity.", ex);
        }
    }
}
