using Microsoft.AspNetCore.Mvc;
using MoneyApp.Controllers.Authorization;
using MoneyApp.DB.Interface.Authorization;
using MoneyApp.Interface.Transaction;
using MoneyApp.Models.User;
using MoneyApp.Other.State.Authorization;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAppUnitTests.Controllers.Transaction.Helper
{
    public class AccountHelper
    {
        private int userId=5;
        private static Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
        private Mock<AccountState> mockState = new Mock<AccountState>();
        public UserController Controller = new UserController();

        private static UserModel MoqEmpty = null;
        private static UserModel MoqFull = new UserModel();
        private static UserModel MockResult { get; set; }

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
            mockRepository.Setup(a => a.Get(userId))
                                  .Returns(MockResult);
            Console.WriteLine("AccountHelper");
        }
    }
}
