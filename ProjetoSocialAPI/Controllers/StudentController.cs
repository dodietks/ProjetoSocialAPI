using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoSocialAPI.Models;
using ProjetoSocialAPI.Services;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        // GET api/<StudentController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentService.FindAll());
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var student = _studentService.FindByID(id);
            if (student is null) return NotFound();
            return Ok(student);
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (student is null) return BadRequest();
            return Ok(_studentService.Create(student));
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Student student)
        {
            if (student is null) return BadRequest();
            return Ok(_studentService.Update(student));
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _studentService.Delete(id);
            return NoContent();
        }
    }
}
