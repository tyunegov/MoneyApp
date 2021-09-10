using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MoneyApp.Other.State
{
    public class TypeTransactionState: ControllerBase
    {
        public override OkObjectResult Ok([ActionResultObjectValue] object value)
        {
            return base.Ok(value);
        }
    }
}
