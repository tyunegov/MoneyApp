using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyApp.Controllers;
using MoneyApp.Models;
using MoneyApp.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MoneyApp.Repository.Tests
{
    [TestClass()]
    public class TransactionRepositoryTests
    {
        private IEnumerable<TransactionModel> MoqTransactions()
        {
            var users = new List<TransactionModel>
            {
                new TransactionModel { Id=1, Amount=10, Date=DateTime.Now, Description="", Type=new TypeTransactionModel{Id=1, Type="type1" } },
                new TransactionModel { Id=2, Amount=20, Date=DateTime.Now, Description="", Type=new TypeTransactionModel{Id=1, Type="type2" } },
                new TransactionModel { Id=3, Amount=30, Date=DateTime.Now, Description="", Type=new TypeTransactionModel{Id=1, Type="type3" } },
            };
            return users;
        }
        #region GetAll
        [TestMethod()]
        public void GetAllTest()
        {
            // Arrange
            var mock = new Mock<ITransactionRepository>();
            mock.Setup(a => a.GetAll()).Returns(MoqTransactions());
            TransactionController controller = new TransactionController(mock.Object);

            // Act
            IEnumerable<TransactionModel> result = controller.GetAll();
            // Assert
            mock.Verify(r => r.GetAll(), Times.Once, "Не был вызван метод repository.GetAll()");            
            Assert.AreEqual(MoqTransactions().Count(), result.Count(), "Не соответствует количество элементов");
        }
        #endregion
        #region Get(id)
        [TestMethod()]
        public void Get1ShouldOk()
        {
            TransactionModel model = MoqTransactions().FirstOrDefault();
            // Arrange
            var mock = new Mock<ITransactionRepository>();
            mock.Setup(a => a.Get(1)).Returns(model);
            TransactionController controller = new TransactionController(mock.Object);
            // Act
            var result = controller.Get(1);
            // Assert
            mock.Verify(r => r.Get(1), Times.Once, "Метод repository.Get(1) не был вызван 1 раз");
            Assert.IsTrue(result is OkObjectResult, "Статус код ОК");
        }

        [TestMethod()]
        public void Get0ShouldNotFound()
        {
            TransactionModel model = null;
            // Arrange
            var mock = new Mock<ITransactionRepository>();
            mock.Setup(a => a.Get(0)).Returns(model);
            TransactionController controller = new TransactionController(mock.Object);
            // Act
            var result = controller.Get(0);
            // Assert
            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.AreEqual("Transaction not found by id 0", ((BadRequestObjectResult)result).Value);
        }
        #endregion
        #region Delete(id)
        /// <summary>
        /// Удаление происходит, объект имеется в БД
        /// </summary>
        [TestMethod()]
        public void Delete1ShouldOk()
        {
            TransactionModel model = MoqTransactions().FirstOrDefault();
            // Arrange
            var mock = new Mock<ITransactionRepository>();
            mock.Setup(a => a.Get(1)).Returns(model);
            TransactionController controller = new TransactionController(mock.Object);
            // Act
            var result = controller.Delete(1);
            // Assert
            mock.Verify(r => r.Delete(1), Times.Once, "Вызов метода repository.Delete(1) 1 раз");
            Assert.IsTrue(result is OkObjectResult, "Статус код ОК");
        }

        /// <summary>
        /// При успешном удалении в статусе удаленный объект
        /// </summary>
        [TestMethod()]
        public void Delete1ReturnTransaction1()
        {
            TransactionModel model = MoqTransactions().FirstOrDefault();
            // Arrange
            var mock = new Mock<ITransactionRepository>();
            mock.Setup(a => a.Get(1)).Returns(model);
            TransactionController controller = new TransactionController(mock.Object);
            // Act
            IActionResult result = controller.Delete(1);
            // Assert
            Assert.AreEqual(model, ((OkObjectResult)result).Value);
        }

        /// <summary>
        /// Объект в БД не найден, возвращается статус 404
        /// </summary>
        [TestMethod()]
        public void Delete0ShouldNotFound()
        {
            TransactionModel model = null;
            // Arrange
            var mock = new Mock<ITransactionRepository>();
            mock.Setup(a => a.Get(0)).Returns(model);
            TransactionController controller = new TransactionController(mock.Object);
            // Act
            var result = controller.Delete(0);
            // Assert
            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.AreEqual("Transaction not found by id 0", ((BadRequestObjectResult)result).Value);
        }
        #endregion
    }
}