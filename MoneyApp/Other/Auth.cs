using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace MoneyApp.Other
{
    public class Auth : Controller
    {
        int? userId;
        public int UserId
        {
            get
            {
                if (userId == null) userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                return userId.Value;
            }
            set => userId = value;
        }
    }
}
