using Microsoft.AspNetCore.Mvc;
using MoneyApp.Models;
using MoneyApp.Other;
using MoneyApp.Repository;
using System;
using System.Collections.Generic;

namespace MoneyApp.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        ITransactionRepository repository;
        public TransactionController(ITransactionRepository repository)
        {
            this.repository = repository;
        }
        #region Post
        /// <summary>
        /// Добавление транзакции
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Post")]
        public IActionResult Post([FromBody]TransactionModel transaction)
        {
                TransactionStatus result = repository.Insert(ref transaction);
                if (result == TransactionStatus.NotFound) return NotFound($"Type not found by id {transaction.Type.Id}");
                if (result == TransactionStatus.FailedToWriteTransaction) return BadRequest($"Failed to write transaction");
                return Created("", transaction);
        }
        #endregion

        #region Get
        /// <summary>
        /// Получить все транзакции
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("All")]
        public IEnumerable<TransactionModel> GetAll()
        {
            return repository.GetAll();
        }

        /// <summary>
        /// Получить транзакции по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            TransactionModel transaction = repository.Get(id);
            if(transaction==null)
                return NotFound($"Transaction not found by id {id}");
            return Ok(transaction);
        }
        #endregion
        #region PUT
        /// <summary>
        /// Изменение транзакции
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Put/{id}")]
        public IActionResult Put(int id, [FromBody] TransactionModel transaction)
        {
            TransactionStatus result = repository.Update(id, ref transaction);
            if (result == TransactionStatus.NotFound) return NotFound($"Transaction not found by id {transaction.Type.Id}");
            return Created("", transaction);
        }
        #endregion
        #region Delete
        /// <summary>
        /// Удаление транзакции
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            TransactionModel transaction = repository.Get(id);
            if (transaction == null)
                return NotFound($"Transaction not found by id {id}");
            repository.Delete(id);
            return Ok(transaction);
        }
        #endregion
    }
}
