using Microsoft.AspNetCore.Mvc;
using MoneyApp.Models;
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

        [HttpGet]
        [Route("All")]
        public IEnumerable<TransactionModel> GetAll()
        {
            return repository.GetAll();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            TransactionModel transaction = repository.Get(id);
            if(transaction==null)
                return BadRequest($"Transaction not found by id {id}");
            return Ok(transaction);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            TransactionModel transaction = repository.Get(id);
            if (transaction == null)
                return BadRequest($"Transaction not found by id {id}");
            repository.Delete(id);
            return Ok(transaction);
        }
    }
}
