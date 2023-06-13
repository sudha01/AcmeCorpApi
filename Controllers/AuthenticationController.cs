using AcmeCorpAPI.Data.Models;
using AcmeCorpAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ServiceStack.Auth;

namespace AcmeCorpAPI.Controllers
{ 
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;
        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]User model)
        {
            var user = _authenticateService.Authenticate(model.UserName, model.Password);
            if(user == null)
                return BadRequest(new {msg = "User name or pwd is incorrect"});

            return Ok(user);    
        }
    }
}
