using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

using PizzaShopManagerApi.Models;
using PizzaShopManagerApi.Models.DataTransferObjects;
using PizzaShopManagerApi.Services;

namespace PizzaShopManagerApi.Controllers;

public class ApplicationControllerBase<TEntity, TDtoEntity, TService> : ControllerBase
    where TEntity : ModelBase
    where TService : IServiceBase<TEntity>
    where TDtoEntity : DtoBase
{
    private readonly TService _service;

    public ApplicationControllerBase(TService service)
    {
        _service = service;
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            return Ok(await _service.GetById(id));
        }
        catch (ServiceException ex)
        {
            return BadRequest(new ErrorResponse
            {
                Message = ex.Message,
                ErrorCode = "EntityNotFound"
            });
        }
    }

    [HttpPost]
    public virtual async Task<IActionResult> Create([FromBody] TDtoEntity dtoEntity)
    {
        try
        {
            await _service.Add(dtoEntity);
            return Ok(); // TODO
        }
        catch (ValidationException ex)
        {
            return BadRequest(new ErrorResponse
            {
                Message = ex.Message,
                ErrorCode = "ValidationFailed"
            });
        }
    }

    [HttpPut("{id}")]
    public virtual async Task<IActionResult> Update(
        [FromRoute] int id, [FromBody] TDtoEntity dtoEntity)
    {
        try
        {
            await _service.Update(id, dtoEntity);
            return Ok();
        }
        catch (ServiceException ex)
        {
            return BadRequest(new ErrorResponse
            {
                Message = ex.Message,
                ErrorCode = "EntityNotFound"
            });
        }
        catch (ValidationException ex)
        {
            return BadRequest(new ErrorResponse
            {
                Message = ex.Message,
                ErrorCode = "ValidationFailed"
            });
        }
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            await _service.Delete(id);
            return Ok();
        }
        catch (ServiceException ex)
        {
            return BadRequest(new ErrorResponse
            {
                Message = ex.Message,
                ErrorCode = "EntityNotFound"
            });
        }
    }

}
