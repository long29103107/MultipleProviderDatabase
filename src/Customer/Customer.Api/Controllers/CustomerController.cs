using Microsoft.AspNetCore.Mvc;
using Customer.Service.DTO;
using Customer.Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
namespace Customer.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;
    public CustomerController(ICustomerService service)
    {
        _service = service;
    }
    [HttpGet(Name = "customer.getlist")]
    [SwaggerOperation(Tags = new[] { "Customer" })]
    [ProducesResponseType(typeof(List<CustomerReponse>), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<List<CustomerReponse>>> GetListAsync([FromQuery] ListCustomerRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.GetListAsync(request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpGet("{id}", Name = "customer.getdetail")]
    [SwaggerOperation(Tags = new[] {"Customer" })]
    [ProducesResponseType(typeof(CustomerReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<CustomerReponse>> GetDetailAsync(int id)
    {
        if(ModelState.IsValid)
        { 
            return Ok(await _service.GetDetailAsync(id));  
        }
        throw new Exception("Model is invalid");
    }
    [HttpPost(Name = "customer.create")]
    [SwaggerOperation(Tags = new[] { "Customer" })]
    [ProducesResponseType(typeof(CustomerReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<CustomerReponse>> CreatAsync(CustomerCreateRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.CreateAsync(request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpPut("{id}", Name = "customer.update")]
    [SwaggerOperation(Tags = new[] { "Customer" })]
    [ProducesResponseType(typeof(CustomerReponse), ((int)HttpStatusCode.OK))]
    public async Task<ActionResult<CustomerReponse>> UpdateAsync(int id, CustomerUpdateRequest request)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _service.UpdateAsync(id, request));
        }
        throw new Exception("Model is invalid");
    }
    [HttpDelete("{id}", Name = "customer.delete")]
    [SwaggerOperation(Tags = new[] { "Customer" })]
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
