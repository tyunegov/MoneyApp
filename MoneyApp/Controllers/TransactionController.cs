using Microsoft.AspNetCore.Mvc;
using MoneyApp.Models;
using MoneyApp.Other;
using MoneyApp.Other.State;
using MoneyApp.Repository;
using System;
using System.Collections.Generic;
using System.ComponenTransactionModelodel.DataAnnotations;
using System.Linq;

namespace MoneyApp.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private AbstractState<R, TransactionModel> state;
        public AbstractState<R, TransactionModel> State { private get; set; }

        ITransactionRepository<IActionResult, TransactionModel> repository;
        public TransactionController(ITransactionRepository<IActionResult, TransactionModel> repository)
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
        public IActionResult Post([FromBody]TransactionModel transaction)
        {   
                return repository.Insert(ref transaction);

                if (result == TransactionStatus.NotFound) return base.NotFound($"{Other.StatusCode.CATEGORY_NOT_FOUND}: {transaction.Category.Id}");
                if (result == TransactionStatus.FailedToWriteTransaction) return base.BadRequest(Other.StatusCode.FAILED_TO_WRITE_TRANSACTION);
                return Created("", transaction);

            return new Realize<IActionResult, TransactionModel>().State();
            throw new NotImplementedException();
        }
        #endregion

        #region Get

        /// <summary>
        /// Получить все транзакции или одну по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int? id)
        {
            TransactionModel transaction = repository.Get(id).FirstOrDefault();
            if(transaction==null && id==null)
                return NotFound($"Transaction not found by id {id}");
            return Ok(transaction);
        }

        /// <summary>
        /// Вывести отчет по транзакциям за определенный период
        /// </summary>
        /// <param name="startDate">Дата начала отчетного периода</param>
        /// <param name="endDate">Дата окончания отчетного периода</param>
        /// <returns></returns>
        [HttpGet]
        [Route("History")]
        public IActionResult History([Required]DateTime startDate, DateTime? endDate)
        {
           if (endDate == null) endDate = DateTime.Today;
           if (startDate > endDate) return BadRequest($"Дата начала отчетного периода не может быть больше даты окончания отчетного периода");
            IEnumerable<AmountGroupTypeDTOModel> aGroupT = repository.Period<AmountGroupTypeDTOModel>(startDate, endDate.Value);
           if(aGroupT==null || aGroupT.Count()==0) return NotFound("За данный период не найдено транзакций");
            History dto = new History()
            {
                StartDate = startDate,
                EndDate = endDate.Value,
                AmountGroupType = aGroupT
            };
            return Ok(dto);
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
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] TransactionModel transaction)
        {
            TransactionStatus result = repository.Update(id, ref transaction);
            if (result == TransactionStatus.NotFound) return NotFound($"Transaction not found by id {transaction.Category.Id}");
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
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            TransactionModel transaction = repository.Get(id).FirstOrDefault();
            if (transaction == null)
                return NotFound($"Transaction not found by id {id}");
            repository.Delete(id);
            return Ok(transaction);
        }
        #endregion
    }
}
