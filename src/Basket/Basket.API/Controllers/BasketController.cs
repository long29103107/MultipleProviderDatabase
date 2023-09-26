using Microsoft.AspNetCore.Mvc;
using Basket.Service.DTO;
using Basket.Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
namespace Basket.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly IBasketService _service;
    public BasketController(IBasketService service)
    {
        _service = service;
    }
    [HttpGet(Name = "basket.getlist")]
    [SwaggerOperation(Tags = new[] { "Basket" })]
    [ProducesResponseType(typeof(List<BasketReponse>), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<List<BasketReponse>>> GetListAsync([FromQuery] ListBasketRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.GetListAsync(request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpGet("{id}", Name = "basket.getdetail")]
    [SwaggerOperation(Tags = new[] {"Basket" })]
    [ProducesResponseType(typeof(BasketReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<BasketReponse>> GetDetailAsync(int id)
    {
        if(ModelState.IsValid)
        { 
            return Ok(await _service.GetDetailAsync(id));  
        }
        throw new Exception("Model is invalid");
    }
    [HttpPost(Name = "basket.create")]
    [SwaggerOperation(Tags = new[] { "Basket" })]
    [ProducesResponseType(typeof(BasketReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<BasketReponse>> CreatAsync(BasketCreateRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.CreateAsync(request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpPut("{id}", Name = "basket.update")]
    [SwaggerOperation(Tags = new[] { "Basket" })]
    [ProducesResponseType(typeof(BasketReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<BasketReponse>> UpdateAsync(int id, BasketUpdateRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.UpdateAsync(id, request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpDelete("{id}", Name = "basket.delete")]
    [SwaggerOperation(Tags = new[] { "Basket" })]
    [ProducesResponseType(((int)HttpStatusCode.NoContent))]
    public async Task<NoContentResult> DeleteAsync(int id)
    {
        if (ModelState.IsValid)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        throw new Exception("Model is invalid");
    }
}
