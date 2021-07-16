using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoneyApp.Models.User;

namespace MoneyApp.DB.Interface.Authorization
{
    public interface IUserRepository
    {
        UserModel GetUser(string login);
        UserModel GetUser(string login, string password);
        int? Insert(UserModel user);
    }
}
