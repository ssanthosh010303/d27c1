using AutoMapper;

using PizzaShopManagerApi.Models;
using PizzaShopManagerApi.Models.DataTransferObjects;
using PizzaShopManagerApi.Repositories;

namespace PizzaShopManagerApi.Services;

public interface IServiceBase<TEntity> where TEntity : ModelBase
{
    public Task<IList<TEntity>> GetAll();
    public Task<TEntity> GetById(int id);
    public Task<TEntity> Add(DtoBase entity);
    public Task Update(int id, DtoBase entity);
    public Task Delete(int id);
}

public abstract class ServiceBase<TEntity> : IServiceBase<TEntity>
    where TEntity : ModelBase
{
    protected readonly IRepositoryBase<TEntity> _repository;
    protected readonly IMapper _mapper;

    public ServiceBase(IMapper mapper, IRepositoryBase<TEntity> repository)
    {
        _repository = repository
            ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper;
    }

    public virtual async Task<IList<TEntity>> GetAll()
    {
        try
        {
            return await _repository.GetAll();
        }
        catch (RepositoryException ex)
        {
            throw new ServiceException(
                "An error occurred in the service while fetching entities.",
                ex);
        }
    }

    public virtual async Task<TEntity> GetById(int id)
    {
        try
        {
            return await _repository.GetById(id);
        }
        catch (RepositoryException ex)
        {
            throw new ServiceException(
                $"An error occurred in the service while fetching the entity " +
                "with ID: {id}.", ex);
        }
    }

    public virtual async Task<TEntity> Add(DtoBase dtoEntity)
    {
        try
        {
            return await _repository.Add(_mapper.Map<TEntity>(dtoEntity));
        }
        catch (RepositoryException ex)
        {
            throw new ServiceException(
                "An error occurred in the service while adding the entity.",
                ex);
        }
    }

    public virtual async Task Update(int id, DtoBase dtoEntity)
    {
        try
        {
            var existingEntity = await _repository.GetById(id);
            var entity = _mapper.Map(dtoEntity, existingEntity);

            await _repository.Update(entity);
        }
        catch (RepositoryException ex)
        {
            throw new ServiceException(
                "An error occurred in the service while updating the entity.",
                ex);
        }
    }

    public virtual async Task Delete(int id)
    {
        try
        {
            await _repository.Delete(id);
        }
        catch (RepositoryException ex)
        {
            throw new ServiceException(
                "An error occurred in the service while deleting the entity.",
                ex);
        }
    }
}
