using Microsoft.AspNetCore.Mvc;
using MoneyApp.Db.Repository.Transaction;
using MoneyApp.Models;
using MoneyApp.Other.State;
using System.Collections.Generic;

namespace MoneyApp.Controllers.Transaction
{
    [Produces("application/json")]
    [Route("Type")]
    [ApiController]
    public class TypeTransactionController : ControllerBase
    {
        TypeTransactionRepository repo = new TypeTransactionRepository();
        ControllerBase state = new TypeTransactionState();
        #region Get
        /// <summary>
        /// Получить все типы транзакций
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<TypeTransactionModel> model = repo.GetAll();            
            return state.Ok(model);
        }
        #endregion
    }
}
