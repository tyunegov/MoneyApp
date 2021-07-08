using Microsoft.AspNetCore.Mvc;
using MoneyApp.Db.Repository;
using MoneyApp.Interface.Repository;
using MoneyApp.Models;
using MoneyApp.Other.State;
using System.Collections.Generic;
using System.Linq;

namespace MoneyApp.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : MoneyAppControllerBase
    {
        /// <summary>
        /// Получить категории по id или typeId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int? id, int? typeId)
        {
            IEnumerable<CategoryModel> model = base.CategoryRepository.Get(id, typeId);
                if (id != null && model.FirstOrDefault() == null) return base.CategoryState.NotFound($"id: {id}");
            return base.CategoryState.Ok(model);
        }
    }
}
