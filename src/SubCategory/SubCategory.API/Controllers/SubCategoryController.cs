using Microsoft.AspNetCore.Mvc;
using SubCategory.Service.DTO;
using SubCategory.Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
namespace SubCategory.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SubCategoryController : ControllerBase
{
    private readonly ISubCategoryService _service;
    public SubCategoryController(ISubCategoryService service)
    {
        _service = service;
    }
    [HttpGet(Name = "subcategory.getlist")]
    [SwaggerOperation(Tags = new[] { "SubCategory" })]
    [ProducesResponseType(typeof(List<SubCategoryReponse>), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<List<SubCategoryReponse>>> GetListAsync([FromQuery] ListSubCategoryRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.GetListAsync(request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpGet("{id}", Name = "subcategory.getdetail")]
    [SwaggerOperation(Tags = new[] {"SubCategory" })]
    [ProducesResponseType(typeof(SubCategoryReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<SubCategoryReponse>> GetDetailAsync(int id)
    {
        if(ModelState.IsValid)
        { 
            return Ok(await _service.GetDetailAsync(id));  
        }
        throw new Exception("Model is invalid");
    }
    [HttpPost(Name = "subcategory.create")]
    [SwaggerOperation(Tags = new[] { "SubCategory" })]
    [ProducesResponseType(typeof(SubCategoryReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<SubCategoryReponse>> CreatAsync(SubCategoryCreateRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.CreateAsync(request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpPut("{id}", Name = "subcategory.update")]
    [SwaggerOperation(Tags = new[] { "SubCategory" })]
    [ProducesResponseType(typeof(SubCategoryReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<SubCategoryReponse>> UpdateAsync(int id, SubCategoryUpdateRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.UpdateAsync(id, request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpDelete("{id}", Name = "subcategory.delete")]
    [SwaggerOperation(Tags = new[] { "SubCategory" })]
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
