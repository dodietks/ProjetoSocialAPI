using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoSocialAPI.Models;
using ProjetoSocialAPI.Services;

namespace ProjetoSocialAPI.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{versio:apiVersion}/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressService _addressService;

        public AddressController(ILogger<AddressController> logger, IAddressService addressService)
        {
            _logger = logger;
            _addressService = addressService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_addressService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var address = _addressService.FindByID(id);
            if (address is null) return NotFound();
            return Ok(address);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Address address)
        {
            if (address is null) return BadRequest();
            return Ok(_addressService.Create(address));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Address address)
        {
            if (address is null) return BadRequest();
            return Ok(_addressService.Update(address));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _addressService.Delete(id);
            return NoContent();
        }
    }
}
