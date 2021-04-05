using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoSocialAPI.Models;
using ProjetoSocialAPI.Services;

namespace ProjetoSocialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        // GET api/<StudentController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindByID(id);
            if (person is null) return NotFound();
            return Ok(person);
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person is null) return BadRequest();
            return Ok(_personService.Create(person));
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person is null) return BadRequest();
            return Ok(_personService.Update(person));
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
