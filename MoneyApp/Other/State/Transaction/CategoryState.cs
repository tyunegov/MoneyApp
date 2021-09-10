using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NLog;

namespace MoneyApp.Other.State
{
    public class CategoryState: ControllerBase
    {            
        public override NotFoundObjectResult NotFound([ActionResultObjectValue] object value)
        {
            var error = base.NotFound(new ErrorState() 
            {
                Error = Other.StatusCode.CATEGORY_NOT_FOUND,
                Value = "id= " + value
            });
            Log.Error(error);
            return error;
        }
    }
}
