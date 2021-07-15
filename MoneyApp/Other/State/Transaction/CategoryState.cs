using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MoneyApp.Other.State
{
    public class CategoryState: ControllerBase
    {
        public override NotFoundObjectResult NotFound([ActionResultObjectValue] object value)
        {
            return base.NotFound(new ErrorState() 
            {
                Error = Other.StatusCode.CATEGORY_NOT_FOUND,
                Value = "id: " + value
            });
        }
    }
}
