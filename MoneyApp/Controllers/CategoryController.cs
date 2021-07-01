using Microsoft.AspNetCore.Mvc;
using MoneyApp.Models;
using MoneyApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        ICategoryRepository<CategoryModel> repository;
        public CategoryController(ICategoryRepository<CategoryModel> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Получить категории по id или typeId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<CategoryModel> Get(int? id, int? typeId)
        {
            return repository.GetCategory(id, typeId);
        }
    }
}
