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
            return base.BadRequest(new ErrorState()
            {
                Error = Other.StatusCode.LOGIN_NOT_UNIQUE,
                Value = "login: "+ login
            });
        }
        
        public BadRequestObjectResult InvalidLoginOrPassword()
        {
            return base.BadRequest(new ErrorState()
            {
                Error = Other.StatusCode.INVALID_LOGIN_OR_PASSWORD
            });
        }

        public BadRequestObjectResult FailedToWrite([ActionResultObjectValue] object value)
        {
            return BadRequest(
            new ErrorState()
            {
                Error = Other.StatusCode.FAILED_TO_WRITE_TRANSACTION,
                Value = value
            });
        }
    }
}
