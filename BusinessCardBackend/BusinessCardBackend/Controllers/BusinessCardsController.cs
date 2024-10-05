using BUSINESS_CARD_ENTITIES;
using BUSINESS_CARD_REPOSITORIES;
using BUSINESS_CARD_SERVICE;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCardBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessCardsController : ControllerBase
    {
        private readonly IBusinessCardService _businessCardService;

        public BusinessCardsController(IBusinessCardService businessCardService)
        {
            _businessCardService = businessCardService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]BusinessCardParam param)
        {
            var entities = await _businessCardService.SearchAsync(param);
            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BusinessCard businessCard)
        {
            var entities = await _businessCardService.InsertAsync(businessCard);
            return Ok(entities);
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            var entities = await _businessCardService.DeleteAsync(id);
            return Ok(entities);
        }
    }
}
