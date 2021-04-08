﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod()]
        public void GetAllShouldStatusOk()
        {
            //Act
            IRestResponse response = restClient.Execute(TransactionPage.GetAll);
            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod()]
        public void GetAllReturnTransactionModel()
        {
            //Act
            IRestResponse response = restClient.Execute(TransactionPage.GetAll);
            Console.WriteLine(response.Content);
            IEnumerable<TransactionModel> locationResponse = new JsonDeserializer().Deserialize<IEnumerable<TransactionModel>>(response);
            Console.WriteLine(locationResponse);
            // Assert
            Assert.IsTrue(locationResponse is IEnumerable<TransactionModel>);
        }
    }
}