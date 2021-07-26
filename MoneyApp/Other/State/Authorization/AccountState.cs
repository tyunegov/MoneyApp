using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Other.State.Authorization
{
    public class AccountState : ControllerBase
    {
        public BadRequestObjectResult LoginNotUnique(string login)
        {
            var error = base.BadRequest(new ErrorState()
            {
                Error = Other.StatusCode.LOGIN_NOT_UNIQUE,
                Value = "login: "+ login
            });
            Log.Error(error);
            return error;
        }

        public BadRequestObjectResult InvalidLoginOrPassword()
        {
            var error = base.BadRequest(new ErrorState()
            {
                Error = Other.StatusCode.INVALID_LOGIN_OR_PASSWORD
            });
            Log.Error(error);
            return error;
        }

        public NotFoundObjectResult UserNotExist(int id)
        {
            var error =  base.NotFound(new ErrorState()
            {
                Error = Other.StatusCode.USER_NOT_EXIST,
                Value = $"UserId = {id}"
            });
            Log.Error(error);
            return error;
        }

        public ForbidResult Forbid(int userId)
        {
            string error = Other.StatusCode.INVALID_LOGIN_OR_PASSWORD;
            Log.Error($"{error} userId= {userId}");
            return base.Forbid(Other.StatusCode.INVALID_LOGIN_OR_PASSWORD);
        }

        public BadRequestObjectResult FailedToWrite([ActionResultObjectValue] object value)
        {
            var error = BadRequest(
            new ErrorState()
            {
                Error = Other.StatusCode.FAILED_TO_WRITE_TRANSACTION,
                Value = value
            });
            Log.Error(error);
            return error;
        }
    }
}
