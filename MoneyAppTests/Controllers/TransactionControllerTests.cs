using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Net;

namespace MoneyAppAPI.Controllers.Tests
{
    [TestClass()]
    public class TransactionControllerTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            //Arrange
            RestClient client = new RestClient(@"https://localhost:44303/");
            RestRequest request = new RestRequest("Transaction/All", Method.GET);
            //Act
            IRestResponse response = client.Execute(request);
            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }
    }
}