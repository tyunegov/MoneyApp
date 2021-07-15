using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoneyApp.DB.Repository.Authorization;
using MoneyApp.DB.Interface.Repository.Authorization;

namespace MoneyApp.Authorization
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class ValuesController : Controller
    {
        IUserRepository repository = new UserRepository();

        [Route("getlogin")]
        [HttpGet]
        public IActionResult GetLogin()
        {
            var user = repository.GetUser(User.Identity.Name);
            user.Password = null;
            return Ok(user);
        }
    }
}