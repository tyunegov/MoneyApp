using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyApp.Models;
using MoneyAppAPITests.PageObject;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace MoneyAppAPI.Controllers.Tests
{
    [TestClass()]
    public class TransactionControllerTests
    {
        readonly RestClient restClient;

        public TransactionControllerTests()
        {
            restClient = TransactionPage.RestClient;
        }
        #region GetAll
        [TestMethod()]
        public void GetAllShouldStatusOk()
        {
            //Act
            IRestResponse response = restClient.Execute(TransactionPage.GetAll);
            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod()]
        public void GetAllReturnListTransactionModel()
        {
            //Act
            IRestResponse response = restClient.Execute(TransactionPage.GetAll);
            IEnumerable<TransactionModel> locationResponse = new JsonDeserializer().Deserialize<IEnumerable<TransactionModel>>(response);
            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK, "Status OK");
            Assert.IsTrue(locationResponse is IEnumerable<TransactionModel>, "IEnumerable<TransactionModel>");
        }
        #endregion
        #region Get/{id}
        [TestMethod()]
        public void Get1ReturnTransactionModel()
        {
            //Act
            IRestResponse response = restClient.Execute(TransactionPage.Get1Ok);
            TransactionModel locationResponse = new JsonDeserializer().Deserialize<TransactionModel>(response);
            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK, "Status OK");
            Assert.IsTrue(locationResponse is TransactionModel, "TransactionModel");
        }

        [TestMethod()]
        public void Get0ShouldNotFound()
        {
            //Act
            IRestResponse response = restClient.Execute(TransactionPage.Get0NotFound);
            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound, "Статус NotFound");
            Assert.AreEqual(response.Content, "\"Transaction not found by id 0\"");
        }
        #endregion
        #region Delete/{id}
        public void Delete0ShouldNotFound()
        {
            //Act
            IRestResponse response = restClient.Execute(TransactionPage.Delete0NotFound);
            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound, "Статус NotFound");
            Assert.AreEqual(response.Content, "\"Transaction not found by id 0\"");
        }
        #endregion
    }
}