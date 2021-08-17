using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyApp.Controllers.Transaction;
using MoneyApp.Interface.Transaction;
using MoneyApp.Models;
using MoneyApp.Other.State;
using MoneyAppUnitTests;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyApp.Controllers.Transaction.Tests
{
    [TestClass()]
    public class CategoryControllerTests
    {
        private CategoryHelper controller = new CategoryHelper();

        [TestMethod()]
        public void Get_id_typeId_Return_NotFound()
        {
            controller.MockRepositoryReturnEmpty();
            controller.Get(CategoryHelper.Id, CategoryHelper.TypeId);
            controller.Check_Result_NotFound();
        }

        [TestMethod()]
        public void Get_id_typeId_Return_Ok()
        {
            controller.MockRepositoryReturnFull();
            controller.Get(CategoryHelper.Id, CategoryHelper.TypeId);
            controller.Check_Result_Ok();
        }

        [TestMethod()]
        public void Get_null_typeId_Return_Ok()
        {
            controller.MockRepositoryReturnEmpty();
            controller.Get(null, CategoryHelper.TypeId);
            controller.Check_Result_Ok();
        }
    }
}