using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MoneyApp.Other.State
{
    public class TransactionState : ControllerBase
    {
        public new OkObjectResult Ok()
        {
            return base.Ok(Other.StatusCode.SUCCESS);
        }

        public override NotFoundObjectResult NotFound([ActionResultObjectValue] object value)
        {
            var error = base.NotFound(new ErrorState()
                {
                    Error = Other.StatusCode.TRANSACTION_NOT_FOUND,
                    Value = "id= "+value
                });
            Log.Error(error);
            return error;
        }

        public BadRequestObjectResult FailedToWrite([ActionResultObjectValue] object value)
        {
            var error = BadRequest(new ErrorState()
            {
                Error = Other.StatusCode.FAILED_TO_WRITE_TRANSACTION,
                Value = value
            });
            Log.Error(error);
            return error;
        }

        public BadRequestObjectResult WrongFilterDates()
        {
            var error = BadRequest(
            new ErrorState()
            {
                Error = Other.StatusCode.STARTDATE_LATER_THAN_ENDDATE
            });
            Log.Error(error);
            return error;
        }
    }
}
