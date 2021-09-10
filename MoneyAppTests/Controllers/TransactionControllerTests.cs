using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyApp.Models;
using MoneyApp.Models.Transaction;
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
   /*     readonly RestClient restClient;
        IRestResponse responsePostOk;
        TransactionModel locationResponsePostOk;

        public TransactionControllerTests()
        {
            restClient = RestClientSingleton.RestClient;
        }

        [TestInitialize]
        public void Initialize()
        {
            responsePostOk = restClient.Execute(TransactionHelper.PostOk);
            locationResponsePostOk = new JsonDeserializer().Deserialize<TransactionModel>(responsePostOk);
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
            // Assert
            Assert.AreEqual(HttpStatusCode.Created, responsePostOk.StatusCode);
            Assert.IsTrue(locationResponsePostOk.Id>0, "Проверка записи Id");
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

        [TestMethod()]
        public void PostShouldReturnData()
        {
            // Assert

            Assert.AreEqual(TransactionHelper.transaction.Amount, locationResponsePostOk.Amount, "Проверка поля Amount");
            Assert.AreEqual(TransactionHelper.transaction.Date, locationResponsePostOk.Date, "Проверка поля Date");
            Assert.AreEqual(TransactionHelper.transaction.Type.Id, locationResponsePostOk.Type.Id, "Проверка поля TypeId");
            Assert.AreEqual(TransactionHelper.transaction.Description, locationResponsePostOk.Description, "Проверка поля Description");

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
        [TestMethod()]
        public void DeleteShouldStatusOk()
        {
            //Act
            IRestResponse response = restClient.Execute(TransactionHelper.DeleteStatusOk(locationResponsePostOk.Id));
            IEnumerable<TransactionModel> locationResponse = new JsonDeserializer().Deserialize<IEnumerable<TransactionModel>>(response);
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Статус Ok");
        }
        #endregion
   */
    }
}