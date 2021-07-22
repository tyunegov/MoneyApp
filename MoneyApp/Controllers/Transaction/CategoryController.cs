using Microsoft.AspNetCore.Mvc;
using MoneyApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoneyApp.Controllers.Transaction
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
            IEnumerable<CategoryWithChildrenModel> model = base.CategoryRepository.Get(id, typeId);
                if (id != null && model.FirstOrDefault() == null) return base.CategoryState.NotFound(id);
            return base.CategoryState.Ok(model);
        }
    }
}
