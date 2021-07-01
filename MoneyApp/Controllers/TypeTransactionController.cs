using Microsoft.AspNetCore.Mvc;
using MoneyApp.Models;
using MoneyApp.Repository;
using System;
using System.Collections.Generic;

namespace MoneyApp.Controllers
{
    [Produces("application/json")]
    [Route("Type")]
    [ApiController]
    public class TypeTransactionController : ControllerBase
    {
        ITypeTransactionRepository repository;
        public TypeTransactionController(ITypeTransactionRepository repository)
        {
            this.repository = repository;
        }
        #region Get
        /// <summary>
        /// Получить все типы транзакций
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<TypeTransactionModel> GetAll()
        {
            return repository.GetAll();
        }
        #endregion
    }
}
