using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
