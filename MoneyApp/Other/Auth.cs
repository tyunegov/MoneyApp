using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace MoneyApp.Other
{
    public class Auth: Controller
    {
        public int UserId { get => int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value); }
    }
}
