using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Product.Service.DTO;
using Product.Service.Interfaces;
using Shared.Repository.Configuration.Settings;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
namespace Product.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;
    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet(Name = "product.getlist")]
    [SwaggerOperation(Tags = new[] { "Product" })]
    [ProducesResponseType(typeof(List<ProductReponse>), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<List<ProductReponse>>> GetListAsync([FromQuery] ListProductRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.GetListAsync(request));
        }
        throw new Exception("Model is invalid");
    }

    [HttpGet("{id}", Name = "product.getdetail")]
    [SwaggerOperation(Tags = new[] { "Product" })]
    [ProducesResponseType(typeof(ProductReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<ProductReponse>> GetDetailAsync(int id)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.GetDetailAsync(id));
        }
        throw new Exception("Model is invalid");
    }
    [HttpPost(Name = "product.create")]
    [SwaggerOperation(Tags = new[] { "Product" })]
    [ProducesResponseType(typeof(ProductReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<ProductReponse>> CreatAsync(ProductCreateRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.CreateAsync(request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpPut("{id}", Name = "product.update")]
    [SwaggerOperation(Tags = new[] { "Product" })]
    [ProducesResponseType(typeof(ProductReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<ProductReponse>> UpdateAsync(int id, ProductUpdateRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.UpdateAsync(id, request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpDelete("{id}", Name = "product.delete")]
    [SwaggerOperation(Tags = new[] { "Product" })]
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
