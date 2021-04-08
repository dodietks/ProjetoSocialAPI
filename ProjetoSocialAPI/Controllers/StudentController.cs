using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoSocialAPI.Business;
using ProjetoSocialAPI.Models;
using System.Collections.Generic;

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

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<Student>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_studentBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Student))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var student = _studentBusiness.FindByID(id);
            if (student is null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(Student))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] Student student)
        {
            if (student is null) return BadRequest();
            return Ok(_studentBusiness.Create(student));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(Student))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] Student student)
        {
            if (student is null) return BadRequest();
            return Ok(_studentBusiness.Update(student));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _studentBusiness.Delete(id);
            return NoContent();
        }
    }
}
