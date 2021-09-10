using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyApp.Models;
using MoneyApp.Models.Transaction;
using MoneyApp.Models.User;
using MoneyApp.Other;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyApp.Controllers.Transaction
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : MoneyAppControllerBase
    {
        #region Post
        /// <summary>
        /// Добавление транзакции
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] TransactionModel<CategoryModel> transaction)
        {
            int userId = new Auth().UserId;
            if (!User.IsInRole("admin")&&transaction.UserId != userId) return base.AccountState.Forbid(userId);

            CategoryWithChildrenModel category = base.CategoryRepository.Get(transaction.Category.Id).FirstOrDefault();
                if (category == null) return base.CategoryState.NotFound(transaction.Category.Id);
            TransactionModel<CategoryWithParentModel> result =  base.TransactionRepository.Insert(transaction);
                if (result == null) return base.TransactionState.FailedToWrite(transaction);

            return base.TransactionState.Created("", result);
        }
        #endregion

        #region Get
        /// <summary>
        /// Получить все транзакции или одну по id
        /// </summary>
        /// <param name="id">id транзакции</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int? id)
        {
            IEnumerable<TransactionModel<CategoryWithParentModel>> model = base.TransactionRepository.Get(base.Auth.UserId, id);
            if (model.FirstOrDefault()==null) return base.TransactionState.NotFound(id);
            return base.TransactionState.Ok(model);
        }

        /// <summary>
        /// Получить все транзакции или одну по id
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="id">id транзакции</param>
        /// <returns></returns>
        [HttpGet]
        [Route("userId")]
        [Authorize(Roles = "admin")]
        public IActionResult Get(int userId, int? id)
        {
            if (base.UserRepository.Get(userId) == null) return base.AccountState.UserNotExist(userId);

            IEnumerable<TransactionModel<CategoryWithParentModel>> model = base.TransactionRepository.Get(userId, id);
            if (model.FirstOrDefault()==null&&id!=null) return base.TransactionState.NotFound(id);
            return base.TransactionState.Ok(model);
        }

        /// <summary>
        /// Вывести отчет по транзакциям за определенный период
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="startDate">Дата начала отчетного периода</param>
        /// <param name="endDate">Дата окончания отчетного периода</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Report")]
        public IActionResult Report(int userId, DateTime? startDate, DateTime? endDate)
        {
            if (!User.IsInRole("admin") && new Auth().UserId != userId) return base.AccountState.Forbid(userId);
            if (startDate > endDate) return base.TransactionState.WrongFilterDates();
            if (startDate == null) startDate = new DateTime();
            if (endDate == null) endDate = DateTime.Today;
            IEnumerable<AmountGroupTypeDTOModel> model = base.TransactionRepository.Period(userId, startDate.Value, endDate.Value);
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
        public IActionResult Put(int id, [FromBody] TransactionModel<CategoryModel> transaction)
        {
            int userId = new Auth().UserId;
            if (!User.IsInRole("admin") && userId != transaction.UserId) return base.AccountState.Forbid(userId);

            TransactionModel<CategoryWithParentModel> _transaction = base.TransactionRepository.Get(transaction.UserId.Value, id).FirstOrDefault();
                if(_transaction==null) return base.TransactionState.NotFound(transaction.Id);

            CategoryWithChildrenModel category = base.CategoryRepository.Get(transaction.Category.Id).FirstOrDefault();
                if (category == null) return base.CategoryState.NotFound(transaction.Category.Id);

            TransactionModel<CategoryWithParentModel> result = base.TransactionRepository.Update(id, ref transaction);
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
            IEnumerable<TransactionModel<CategoryWithParentModel>> _transaction = null;
            if (!IsAdmin) _transaction = base.TransactionRepository.Get(Auth.UserId, id);
            if (IsAdmin) _transaction = base.TransactionRepository.Get(null, id);
            
            if (_transaction.FirstOrDefault() == null) return base.TransactionState.NotFound(id);

            if(!base.TransactionRepository.Delete(id)) return base.TransactionState.BadRequest();
            return base.TransactionState.Ok();
        }
        #endregion
    }
}
