using BUSINESS_CARD_CORE;
using BUSINESS_CARD_ENTITIES;
using BUSINESS_CARD_SERVICE.CommonServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCardBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  // Sp is SearchParams
  public class CommonController<T , S , SP> : ControllerBase
    where T : BaseEntity
    where SP : BaseParam
    where S : IBaseService<T,SP>
  {
    protected readonly S _service;

    public CommonController(S service)
    {
      _service = service;
    }

    [HttpGet]
    public virtual async Task<IActionResult> Get([FromQuery] SP param)
    {
      var entities = await _service.SearchAsync(param);
      return Ok(entities);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Post(T item)
    {
      var entities = await _service.InsertAsync(item);
      return Ok(entities);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
      var entities = await _service.DeleteAsync(id);
      return Ok(entities);
    }
  }
}
