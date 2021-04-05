using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoSocialAPI.Models;
using ProjetoSocialAPI.Services;

namespace ProjetoSocialAPI.Controllers
{
    [Route("api/[controller]")]
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

        // GET api/<StudentController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_addressService.FindAll());
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var address = _addressService.FindByID(id);
            if (address is null) return NotFound();
            return Ok(address);
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] Address address)
        {
            if (address is null) return BadRequest();
            return Ok(_addressService.Create(address));
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Address address)
        {
            if (address is null) return BadRequest();
            return Ok(_addressService.Update(address));
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _addressService.Delete(id);
            return NoContent();
        }
    }
}
