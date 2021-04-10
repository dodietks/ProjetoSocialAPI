using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoSocialAPI.Business;
using System.Collections.Generic;
using ProjetoSocialAPI.Data.ValueObject;
using System;
using ProjetoSocialAPI.Hypermedia.Filters;

namespace ProjetoSocialAPI.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressBusiness _addressBusiness;

        public AddressController(ILogger<AddressController> logger, IAddressBusiness addressService)
        {
            _logger = logger;
            _addressBusiness = addressService;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(List<AddressVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_addressBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(AddressVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var address = _addressBusiness.FindByID(id);
            if (address is null) return NotFound();
            return Ok(address);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(AddressVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] AddressVO address)
        {
            if (address is null) return BadRequest();
            return Ok(_addressBusiness.Create(address));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(AddressVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] AddressVO address)
        {
            if (address is null) return BadRequest();
            return Ok(_addressBusiness.Update(address));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _addressBusiness.Delete(id);
            return NoContent();
        }
    }
}
