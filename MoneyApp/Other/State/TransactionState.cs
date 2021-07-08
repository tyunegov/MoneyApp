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
            return base.NotFound(
                new ErrorState()
                {
                    Error = Other.StatusCode.TRANSACTION_NOT_FOUND,
                    Value = value
                }
                );
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

        public BadRequestObjectResult WrongFilterDates()
        {
            return BadRequest(
            new ErrorState()
            {
                Error = Other.StatusCode.STARTDATE_LATER_THAN_ENDDATE
            });
        }
    }
}
