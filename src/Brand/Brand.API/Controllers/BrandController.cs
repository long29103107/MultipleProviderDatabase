using Microsoft.AspNetCore.Mvc;
using Brand.Service.DTO;
using Brand.Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
namespace Brand.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandService _service;
    public BrandController(IBrandService service)
    {
        _service = service;
    }
    [HttpGet(Name = "brand.getlist")]
    [SwaggerOperation(Tags = new[] { "Brand" })]
    [ProducesResponseType(typeof(List<BrandReponse>), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<List<BrandReponse>>> GetListAsync([FromQuery] ListBrandRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.GetListAsync(request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpGet("{id}", Name = "brand.getdetail")]
    [SwaggerOperation(Tags = new[] {"Brand" })]
    [ProducesResponseType(typeof(BrandReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<BrandReponse>> GetDetailAsync(int id)
    {
        if(ModelState.IsValid)
        { 
            return Ok(await _service.GetDetailAsync(id));  
        }
        throw new Exception("Model is invalid");
    }
    [HttpPost(Name = "brand.create")]
    [SwaggerOperation(Tags = new[] { "Brand" })]
    [ProducesResponseType(typeof(BrandReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<BrandReponse>> CreatAsync(BrandCreateRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.CreateAsync(request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpPut("{id}", Name = "brand.update")]
    [SwaggerOperation(Tags = new[] { "Brand" })]
    [ProducesResponseType(typeof(BrandReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<BrandReponse>> UpdateAsync(int id, BrandUpdateRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.UpdateAsync(id, request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpDelete("{id}", Name = "brand.delete")]
    [SwaggerOperation(Tags = new[] { "Brand" })]
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
