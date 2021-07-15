using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoneyApp.DB.Interface.Repository.Authorization;
using MoneyApp.DB.Repository.Authorization;
using MoneyApp.Models.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MoneyApp.Controllers.Authorization
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        IUserRepository repository = new UserRepository();

        [HttpPost("/Token")]
        public IActionResult Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthorizationStartup.ISSUER,
                    audience: AuthorizationStartup.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthorizationStartup.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthorizationStartup.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
        }

        [HttpGet]
        public IActionResult GetLogin()
        {
            var user = repository.GetUser(User.Identity.Name);
            user.Password = null;
            return Ok(user);
        }

        private ClaimsIdentity GetIdentity(string login, string password)
        {
            UserModel person = repository.GetUser(login, password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}