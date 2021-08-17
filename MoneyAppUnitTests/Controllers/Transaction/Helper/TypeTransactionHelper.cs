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

namespace MoneyAppUnitTests.Controllers.Transaction.Helper
{
    class TypeTransactionHelper:Helper
    {
   //     public void MockRepository()
   //     {
   ////         Setup(mockTypeTransactionFull);
   //     }

        //public void Setup(IEnumerable<TypeTransactionModel> mock)
        //{
        //    //mockTypeTransactionRepository.Setup(a => a.GetAll())
        //    //                      .Returns(mock);
        //    //typeTransactionController.TypeTransactionRepository = mockTypeTransactionRepository.Object;
        //    //typeTransactionController.TypeTransactionState = mockTypeTransactionState.Object;
        //}

        //public IActionResult Get()
        //{
        //    //var result = typeTransactionController.Get();
        //    //mockTypeTransactionRepository.Verify(r => r.GetAll(), Times.Once, "Не был вызван метод repository.Get()");
        //    //return result;
        //}

        //public void CheckResultOk()
        //{
        //    //mockTypeTransactionState.Verify(r => r.Ok(mockTypeTransactionFull), Times.Once, "Не был вызван метод Ok()");
        //}
    }
}

