using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoSocialAPI.Business;
using ProjetoSocialAPI.Data.ValueObject;
using ProjetoSocialAPI.Hypermedia.Filters;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Controllers
{
    [ApiVersion("1")]
    [Authorize("Bearer")]
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
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(List<StudentVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            var response = _studentBusiness.FindAll();
            _logger.LogInformation("response");
            return Ok(response);
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(StudentVO))]
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
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(StudentVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] StudentVO student)
        {
            if (student is null) return BadRequest();
            return Ok(_studentBusiness.Create(student));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(StudentVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] StudentVO student)
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
