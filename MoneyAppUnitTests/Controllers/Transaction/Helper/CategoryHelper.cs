using Microsoft.AspNetCore.Mvc;
using MoneyApp.Controllers.Transaction;
using MoneyApp.Interface.Transaction;
using MoneyApp.Models;
using MoneyApp.Other.State;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAppUnitTests
{
    public class CategoryHelper
    {
        public static int Id { get => 5; }
        public static int TypeId { get => 2; }

        private Mock<ICategoryRepository> mockRepository = new Mock<ICategoryRepository>();
        private Mock<CategoryState> mockState = new Mock<CategoryState>();
        private CategoryController controller = new CategoryController();

        private static IEnumerable<CategoryWithChildrenModel> MoqEmpty = new List<CategoryWithChildrenModel>();
        private static IEnumerable<CategoryWithChildrenModel> MoqFull = new List<CategoryWithChildrenModel>()
        {
            new CategoryWithChildrenModel()
        };

        private static IEnumerable<CategoryWithChildrenModel> MockResult { get; set; }

        public void MockRepositoryReturnEmpty()
        {
            MockResult = MoqEmpty;
            Setup();
        }
        public void MockRepositoryReturnFull()
        {
            MockResult = MoqFull;
            Setup();
        }

        public void Setup()
        {
            mockRepository.Setup(a => a.Get(Id, TypeId))
                                  .Returns(MockResult);
            controller.CategoryRepository = mockRepository.Object;
            controller.CategoryState = mockState.Object;
        }

        public IActionResult Get(int? id, int? typeId)
        {
            var result = controller.Get(id, typeId);
            mockRepository.Verify(r => r.Get(id, typeId), Times.Once);
            return result;
        }

        public void Check_Result_NotFound()
        {
            mockState.Verify(r => r.NotFound(Id), Times.Once);
        }

        public void Check_Result_Ok()
        {
            mockState.Verify(r => r.Ok(MockResult), Times.Once, "Не был вызван метод Ok()");
        }
    }
}
