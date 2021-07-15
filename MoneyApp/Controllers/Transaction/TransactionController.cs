using Microsoft.AspNetCore.Mvc;
using MoneyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyApp.Controllers.Transaction
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : MoneyAppControllerBase
    {

        #region Post
        /// <summary>
        /// Добавление транзакции
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]TransactionModel transaction)
        {                        
            CategoryModel category = base.CategoryRepository.Get(transaction.Category.Id).FirstOrDefault();
                if (category == null) return base.CategoryState.NotFound("categoryId: "+transaction.Category.Id);
            TransactionModel result = base.TransactionRepository.Insert(transaction);
                if (result == null) return base.TransactionState.FailedToWrite(transaction);

            return base.TransactionState.Created("", result);
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
            IEnumerable<TransactionModel> model = base.TransactionRepository.Get(id);
                if (id != null && model.FirstOrDefault() == null) return base.TransactionState.NotFound($"id: {id}");
            return base.TransactionState.Ok(model);
        }

        /// <summary>
        /// Вывести отчет по транзакциям за определенный период
        /// </summary>
        /// <param name="startDate">Дата начала отчетного периода</param>
        /// <param name="endDate">Дата окончания отчетного периода</param>
        /// <returns></returns>
        [HttpGet]
        [Route("History")]
        public IActionResult History(DateTime? startDate, DateTime? endDate)
        {
            if (startDate > endDate) return base.TransactionState.WrongFilterDates();
            if (startDate == null) startDate = new DateTime();
            if (endDate == null) endDate = DateTime.Today;
            IEnumerable<AmountGroupTypeDTOModel> model = base.TransactionRepository.Period(startDate.Value, endDate.Value);
            return base.TransactionState.Ok(model);
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
            TransactionModel _transaction = base.TransactionRepository.Get(id).FirstOrDefault();
                if(_transaction==null) return base.TransactionState.NotFound($"id: {transaction.Id}");

            CategoryModel category = base.CategoryRepository.Get(transaction.Category.Id).FirstOrDefault();
                if (category == null) return base.CategoryState.NotFound($"id: {transaction.Id}");

            TransactionModel result = base.TransactionRepository.Update(id, ref transaction);
            return base.TransactionState.Created("", transaction);
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
            TransactionModel _transaction = base.TransactionRepository.Get(id).FirstOrDefault();
            if (_transaction == null) return base.TransactionState.NotFound($"id: {id}");

            if(!base.TransactionRepository.Delete(id)) return base.TransactionState.BadRequest();
            return base.TransactionState.Ok();
        }
        #endregion
    }
}
