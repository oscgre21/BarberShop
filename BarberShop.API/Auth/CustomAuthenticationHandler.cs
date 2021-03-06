using BarberShop.Services.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BarberShop.API.Auth
{
    public class BasicAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

        public string Scheme => DefaultScheme;
    }
 
    public class CustomAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        private readonly IAuthenticationManager customAuthenticationManager;
 
        public CustomAuthenticationHandler(
            IOptionsMonitor<BasicAuthenticationOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock,
            IAuthenticationManager customAuthenticationManager) 
            : base(options, logger, encoder, clock)
        {
            this.customAuthenticationManager = customAuthenticationManager;
        }
 
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Unauthorized");
 
            string authorizationHeader = Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                return AuthenticateResult.NoResult();
            }
 
            if (!authorizationHeader.StartsWith("bearer", StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }
 
            string token = authorizationHeader.Substring("bearer".Length).Trim();
 
            if (string.IsNullOrEmpty(token))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }
 
            try
            {
                return validateToken(token);
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex.Message);
            }
        }
 
        private AuthenticateResult validateToken(string token)
        {
            var validatedToken = customAuthenticationManager.Validate(token);
           
            var data = validatedToken.Match(leftFunc =>
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, leftFunc.persona.NameComplete),
                };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new System.Security.Principal.GenericPrincipal(identity, null);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            },rightFunc => AuthenticateResult.Fail("Unauthorized"));
             
            return data;
        }
    }
}
