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
            Assert.IsTrue(result is NotFoundObjectResult);
            Assert.AreEqual("Transaction not found by id 0", ((NotFoundObjectResult)result).Value);
        }
    }
}