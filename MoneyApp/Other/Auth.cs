using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace MoneyApp.Other
{
    public class Auth: Controller
    {
        public string UserId { get => User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value; }
    }
}
