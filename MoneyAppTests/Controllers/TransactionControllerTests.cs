using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyApp.Models;
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
        [TestMethod()]
        public void GetAllShouldStatusOk()
        {
            //Arrange
            RestClient client = new RestClient(@"https://localhost:44303/");
            RestRequest request = new RestRequest("Transaction/All", Method.GET);
            //Act
            IRestResponse response = client.Execute(request);
            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod()]
        public void GetAllReturnTransactionModel()
        {
            //Arrange
            RestClient client = new RestClient(@"https://localhost:44303/");
            RestRequest request = new RestRequest("Transaction/All", Method.GET);
            //Act
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            IEnumerable<TransactionModel> locationResponse = new JsonDeserializer().Deserialize<IEnumerable<TransactionModel>>(response);
            Console.WriteLine(locationResponse);
            // Assert
            Assert.IsTrue(locationResponse is IEnumerable<TransactionModel>);
        }
    }
}