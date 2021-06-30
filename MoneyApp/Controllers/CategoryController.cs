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
        /// Получить основные категории по typeId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("MainCategory")]
        public IEnumerable<CategoryModel> MainCategory(int typeId)
        {
            return repository.MainCategory(typeId);
        }
        /// <summary>
        /// Получить подкатегории по categoryId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("SubCategory")]
        public IEnumerable<CategoryModel> SubCategory(int categoryId)
        {
            return repository.SubCategory(categoryId);
        }
    }
}
