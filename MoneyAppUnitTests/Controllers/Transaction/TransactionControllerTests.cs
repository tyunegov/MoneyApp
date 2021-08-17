using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyApp.Controllers.Transaction;
using MoneyAppUnitTests.Controllers.Transaction.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyApp.Controllers.Transaction.Tests
{
    [TestClass()]
    public class TransactionControllerTests:Helper
    {
        int userId = Helper.UserId;
        int id = Helper.Id;
    //    public Helper transaction = new TransactionHelper();
    //    public AccountHelper account = new AccountHelper();

        [TestMethod()]
        public void Get_UserId_Id_Return_NotFound()
        {
                    transaction.MockGet_Return_Empty();
                    transaction.Get(userId, id);
                    transaction.CheckResultNotFound(id);
            
        }

        [TestMethod()]
        public void Get_UserId_Id_Return_UserNotExist()
        {
            transaction.MockGet_Return_Full();
            account.MockRepositoryReturnEmpty();
            transaction.Get(userId, id);
        }

        [TestMethod()]
        public void Get_UserId_Id_Return_Ok()
        {
            
        //    transaction.MockAccountRepository_Return_Null();
            transaction.MockGet_Return_Full();
            transaction.Get(userId, id);
            transaction.CheckResultOk(transaction.MockResult);
            
        }

        [TestMethod()]
        public void Get_Id_Return_NotFound()
        {            
            transaction.MockGet_Return_Empty();
            transaction.Get(id);
            transaction.CheckResultNotFound(id);   
        }
        
        [TestMethod()]
        public void Get_Id_Return_Ok()
        {
            transaction.MockGet_Return_Full();
            transaction.Get(id);
            transaction.CheckResultOk(transaction.MockResult);
        }

        [TestMethod()]
        public void Delete_Return_Ok()
        {
            transaction.MockGet_Return_Full();
            transaction.MockDelete_Return_Full();
            transaction.Delete(id);
     //       transaction.CheckResultOk();
        }

        [TestMethod()]
        public void Delete_Return_NotFound()
        {
            transaction.MockGet_Return_Empty();
            transaction.MockDelete_Return_Full();
            transaction.Delete(id);
            transaction.CheckResultNotFound(id);
     //       transaction.CheckResultOk(id);
        }
        [TestMethod()]
        public void Delete_Return_BadRequest()
        {
                 transaction.MockGet_Return_Full();
         //        transaction.MockDelete_Return_BadRequest();
                 transaction.Delete(id);
        //         transaction.CheckResultBadRequest();
            
        }
    }
}