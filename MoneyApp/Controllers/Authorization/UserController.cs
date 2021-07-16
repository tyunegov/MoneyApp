using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoneyApp.DB.Interface.Authorization;
using MoneyApp.DB.Repository.Authorization;
using MoneyApp.Models.User;
using MoneyApp.Other.State.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MoneyApp.Controllers.Authorization
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        IUserRepository repository = new UserRepository();
        AccountState state = new AccountState();

        [HttpPost("/Token")]
        public IActionResult Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(state.InvalidLoginOrPassword());
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
        [Authorize]
        public IActionResult Get()
        {
            var user = repository.GetUser(User.Identity.Name);
            return Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromBody] UserModel user)
        {
            user.Role = "user";
                if (repository.GetUser(user.Login) != null) return state.LoginNotUnique(user.Login);
            int? id = repository.Insert(user);
                if (id == null) return state.FailedToWrite(user); 
            return state.Created("", repository.GetUser(user.Login));
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