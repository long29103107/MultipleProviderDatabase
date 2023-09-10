using Microsoft.AspNetCore.Mvc;
using Category.Service.DTO;
using Category.Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
namespace Category.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;
    public CategoryController(ICategoryService service)
    {
        _service = service;
    }
    [HttpGet(Name = "category.getlist")]
    [SwaggerOperation(Tags = new[] { "Category" })]
    [ProducesResponseType(typeof(List<CategoryReponse>), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<List<CategoryReponse>>> GetListAsync([FromQuery] ListCategoryRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.GetListAsync(request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpGet("{id}", Name = "category.getdetail")]
    [SwaggerOperation(Tags = new[] {"Category" })]
    [ProducesResponseType(typeof(CategoryReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<CategoryReponse>> GetDetailAsync(int id)
    {
        if(ModelState.IsValid)
        { 
            return Ok(await _service.GetDetailAsync(id));  
        }
        throw new Exception("Model is invalid");
    }
    [HttpPost(Name = "category.create")]
    [SwaggerOperation(Tags = new[] { "Category" })]
    [ProducesResponseType(typeof(CategoryReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<CategoryReponse>> CreatAsync(CategoryCreateRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.CreateAsync(request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpPut("{id}", Name = "category.update")]
    [SwaggerOperation(Tags = new[] { "Category" })]
    [ProducesResponseType(typeof(CategoryReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<CategoryReponse>> UpdateAsync(int id, CategoryUpdateRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.UpdateAsync(id, request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpDelete("{id}", Name = "category.delete")]
    [SwaggerOperation(Tags = new[] { "Category" })]
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
