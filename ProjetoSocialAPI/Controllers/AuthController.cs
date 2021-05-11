using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoSocialAPI.Business;
using ProjetoSocialAPI.Data.ValueObject;
using ProjetoSocialAPI.Hypermedia.Filters;

namespace ProjetoSocialAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpGet]
        [Route("ping")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public string Ping()
        {
            return "pong";
        }

        [HttpPost]
        [Route("signin")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Signin([FromBody] PersonVO person)
        {
            if (person is null) return BadRequest("Invalid client request");
            var token = _loginBusiness.ValidateCredentials(person);
            if (token is null) return Unauthorized();
            return Ok(token);
        }
    }
}
