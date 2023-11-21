using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;


namespace C14AuthSample;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet("secret")]
    public ActionResult<string> GetRestrictedResource()
    {
      var validClaims = GetCl
      var userClaims = HttpContext
        return "This message is top secret!";
    }
    [HttpPost("authenticate")]
    public ActionResult<string> AuthenticateUser([FromBody] Credentials creds)
    {
        
    }
}

