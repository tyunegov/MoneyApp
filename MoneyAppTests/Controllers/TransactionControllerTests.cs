using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyApp.Models;
using MoneyAppAPITests.Helper;
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
        delegate void Message(); // 1. Объявляем делегат
        static int[] nums5 = { 1, 2, 3, 5 };

        public TransactionControllerTests()
        {
            restClient = TransactionHelper.RestClient;
        }
        #region GetAll
        [TestMethod()]
        public void GetAllShouldStatusOk()
        {
            //Act
            IRestResponse response = restClient.Execute(TransactionHelper.GetAll);
            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod()]
        public void GetAllReturnListTransactionModel()
        {
            //Act
            IRestResponse response = restClient.Execute(TransactionHelper.GetAll);
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
            IRestResponse response = restClient.Execute(TransactionHelper.Get1Ok);
            TransactionModel locationResponse = new JsonDeserializer().Deserialize<TransactionModel>(response);
            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK, "Status OK");
            Assert.IsTrue(locationResponse is TransactionModel, "TransactionModel");
        }

        [TestMethod()]
        public void Get0ShouldNotFound()
        {
            //Act
            IRestResponse response = restClient.Execute(TransactionHelper.Get0NotFound);
            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode, "Статус NotFound");
            Assert.AreEqual(response.Content, "\"Transaction not found by id 0\"");
        }
        #endregion
        #region Delete/{id}
        [TestMethod()]
        public void Delete0ShouldNotFound()
        {
            //Act
            IRestResponse response = restClient.Execute(TransactionHelper.Delete0NotFound);
            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode, "Статус NotFound");
            Assert.AreEqual(response.Content, "\"Transaction not found by id 0\"");
        }
        #endregion
        #region Post
        [TestMethod()]
        public void PostShouldFieldIsRequired()
        {
            //Act
            IRestResponse response = restClient.Execute(TransactionHelper.PostNotFound);
            
            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode, "Статус BadRequest");
        }

        [TestMethod()]
        public void PostShouldStatusOK()
        {
            //Act
            IRestResponse response = restClient.Execute(TransactionHelper.PostOk);
            TransactionModel locationResponse = new JsonDeserializer().Deserialize<TransactionModel>(response);
            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsTrue(locationResponse.Id>0, "Проверка записи Id");
        }

        [TestMethod()]
        public void PostShouldTypeNotFound()
        {
            //Act
            IRestResponse response = restClient.Execute(TransactionHelper.PostTypeNotFound);

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode, "Статус NotFound");
            Assert.AreEqual(response.Content, "\"Type not found by id -1\"");
        }
        [DataTestMethod]
        [DataRow("PutWithoutType")]
        [DataRow("PutWithoutDate")] 
        [DataRow("PutWithoutAmountIs0")]
        public void PutRequestFieldsShouldBadRequest(string request)
        {
            IRestRequest rest = TransactionHelper.FakeRestRequest[request];
            //Act
            IRestResponse response = restClient.Execute(TransactionHelper.FakeRestRequest[request]);

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode, "Статус BadRequest");
        }
        #endregion
    }
}