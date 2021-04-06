using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoSocialAPI.Business;
using ProjetoSocialAPI.Models;

namespace ProjetoSocialAPI.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentBusiness _studentBusiness;

        public StudentController(ILogger<StudentController> logger, IStudentBusiness studentService)
        {
            _logger = logger;
            _studentBusiness = studentService;
        }

        // GET api/<StudentController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentBusiness.FindAll());
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var student = _studentBusiness.FindByID(id);
            if (student is null) return NotFound();
            return Ok(student);
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (student is null) return BadRequest();
            return Ok(_studentBusiness.Create(student));
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Student student)
        {
            if (student is null) return BadRequest();
            return Ok(_studentBusiness.Update(student));
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _studentBusiness.Delete(id);
            return NoContent();
        }
    }
}
