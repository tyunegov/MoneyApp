using Microsoft.AspNetCore.Mvc;
using MoneyApp.Models;
using MoneyApp.Repository;
using System.Collections.Generic;

namespace MoneyApp.Controllers
{
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
    }
}
