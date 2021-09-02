using BarberShop.API.Controllers.Base;
using BarberShop.BL.DTOs.Auth;
using BarberShop.BL.DTOs.Global;
using BarberShop.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.API.Controllers.Auth
{

    public class AuthController : BaseMinApiController
    {
        IAuthenticationManager _auth;
        public AuthController(IAuthenticationManager auth) {
            _auth = auth;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")] 
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDto userCred)
        {
            var token = await _auth.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] UserCredentialsDto userCred)
        {
            var token = await _auth.register(userCred);

            if (token == null)
                return StatusCode(452); 

            return Ok(token);
        }
        
        [HttpGet("validateToken")]
        public IActionResult validateToken()
        {   
            var token = Request.Headers["Authorization"]!.ToString().Replace("bearer ", "");
            if (token == null)
                return Unauthorized();

            var isValid = _auth.Validate(token);

            return Ok(isValid);
        }
        [HttpGet("getTokens")]
        public IActionResult getTokens()
        { 
            var token = _auth.Tokens;

            return Ok(token);
        }
    }
}
