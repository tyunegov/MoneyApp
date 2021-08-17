using Microsoft.AspNetCore.Mvc;
using MoneyApp.Controllers.Transaction;
using MoneyApp.Interface.Transaction;
using MoneyApp.Models.Transaction;
using MoneyApp.Other;
using MoneyApp.Other.State;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAppUnitTests.Controllers.Transaction.Helper
{
    public class TransactionHelper
    {
        public static int UserId { get => 5; }
        public static int Id { get => 2; }
        public bool DeleteResult { get; set; }
        private IEnumerable<TransactionModel<CategoryWithParentModel>> mockResult = new List<TransactionModel<CategoryWithParentModel>>();
        private protected TransactionController transactionController = new TransactionController();
        private protected Mock<ITransactionRepository> mockTransactionRepository = new Mock<ITransactionRepository>();
        private protected Mock<TransactionState> mockTransactionState = new Mock<TransactionState>();
        
        public IEnumerable<TransactionModel<CategoryWithParentModel>> MockResult { get => mockResult; set => mockResult=value; }

        public IActionResult Get(int userId, int id)
        {
            var result = transactionController.Get(userId, id);
            mockTransactionRepository.Verify(r => r.Get(userId, id), Times.Once);
            return result;
        }
        public IActionResult Get(int id)
        {
            var result = transactionController.Get(id);
            mockTransactionRepository.Verify(r => r.Get(UserId, id), Times.Once);
            return result; 
        }
        public IActionResult Delete(int id)
        {
            var result = transactionController.Delete(id);
  //          mockTransactionRepository.Verify(r => r.Delete(id), Times.Once);
            return result;
        }
        public void CheckResultNotFound(object obj)
        {
            mockTransactionState.Verify(r => r.NotFound(obj), Times.Once);
        }

        public void CheckResultOk(object obj)
        {
            mockTransactionState.Verify(r => r.Ok(obj), Times.Once);
        }

        public void CheckResultBadRequest(object obj)
        {
            mockTransactionState.Verify(r => r.BadRequest(obj), Times.Once);
        }

        public void MockGet_Return_Empty()
        {
            MockResult = Helper.mockTransactionEmpty;
     //       Setup();
        }
        public void MockGet_Return_Full()
        {
            MockResult = Helper.mockTransactionFull;
            Setup();
        }
        public void MockDelete_Return_Full()
        {
            transactionController.IsAdmin = false;
            DeleteResult = true;
            Setup();
        }

        public virtual void Setup()
        {
            transactionController.Auth.UserId = UserId;
            mockTransactionRepository.Setup(a => a.Get(transactionController.Auth.UserId, Id))
                                  .Returns(MockResult);
            mockTransactionRepository.Setup(a => a.Delete(Id))
                                  .Returns(DeleteResult);
            transactionController.TransactionRepository = mockTransactionRepository.Object;
            transactionController.TransactionState = mockTransactionState.Object;
        }
    }
}
