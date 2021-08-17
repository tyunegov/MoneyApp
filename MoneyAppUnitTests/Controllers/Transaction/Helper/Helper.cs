using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyApp.Controllers.Authorization;
using MoneyApp.Controllers.Transaction;
using MoneyApp.DB.Interface.Authorization;
using MoneyApp.Interface.Transaction;
using MoneyApp.Models;
using MoneyApp.Models.Transaction;
using MoneyApp.Models.User;
using MoneyApp.Other.State;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAppUnitTests.Controllers.Transaction.Helper
{
    [TestClass()]
    public class Helper
    {
        public static int UserId { get => 5; }
        public static int Id { get => 2; }

        private protected Mock<ITransactionRepository> mockTransactionRepository = new Mock<ITransactionRepository>();
        private protected Mock<TransactionState> mockTransactionState = new Mock<TransactionState>();
        private protected TransactionController transactionController = new TransactionController();
        private protected UserController userController = new UserController();
        private protected Mock<ITypeTransactionRepository> mockTypeTransactionRepository = new Mock<ITypeTransactionRepository>();
        private protected Mock<TypeTransactionState> mockTypeTransactionState = new Mock<TypeTransactionState>();
        private protected TypeTransactionController typeTransactionController = new TypeTransactionController();
        public TransactionHelper transaction = new TransactionHelper();
        public AccountHelper account = new AccountHelper();

        Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
        public Mock<IUserRepository> UserRepository { get => mockUserRepository; }

        private protected static IEnumerable<TypeTransactionModel> mockTypeTransactionFull = new List<TypeTransactionModel>()
        {
            new TypeTransactionModel()
        };

        public static IEnumerable<TransactionModel<CategoryWithParentModel>> mockTransactionEmpty = new List<TransactionModel<CategoryWithParentModel>>();
        public static IEnumerable<TransactionModel<CategoryWithParentModel>> mockTransactionFull = new List<TransactionModel<CategoryWithParentModel>>()
        {
            new TransactionModel<CategoryWithParentModel>()
        };

        private protected static UserModel mockUserEmpty = null;
        private protected static UserModel mockUserFull = new UserModel() { Id = 5 };

        public virtual void MockAccountRepository_Return_Null()
        {
            mockUserRepository.Setup(a => a.Get(UserId))
                                  .Returns(mockUserEmpty);
        }
        public virtual void MockAccountRepository_Return_Full()
        {
            mockUserRepository.Setup(a => a.Get(UserId))
                                  .Returns(mockUserEmpty);
        }
        public virtual void CheckResultOk()
        {
            mockTransactionState.Verify(r => r.Ok(), Times.Once);
        }
        public virtual void CheckResultBadRequest()
        {
            mockTransactionState.Verify(r => r.BadRequest(), Times.Once);
        }
    }
}
