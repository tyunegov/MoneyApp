using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyApp.Models;
using MoneyAppAPITests.Helper;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAppAPITests.Controllers
{
    [TestClass()]
    public class TypeTransactionControllerTests
    {
        readonly RestClient restClient;

        public TypeTransactionControllerTests()
        {
            restClient = RestClientSingleton.RestClient;
        }
        #region GetAll
        [TesTransactionModelethod()]
        public void GetAllShouldStatusOk()
        {
            //Act
            IRestResponse response = restClient.Execute(TypeTransactionHelper.GetAll);
            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TesTransactionModelethod()]
        public void GetAllReturnListTypeTransactionModel()
        {
            //Act
            IRestResponse response = restClient.Execute(TypeTransactionHelper.GetAll);
            IEnumerable<TypeTransactionModel> locationResponse = new JsonDeserializer().Deserialize<IEnumerable<TypeTransactionModel>>(response);
            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK, "Status OK");
            Assert.IsTrue(locationResponse is IEnumerable<TypeTransactionModel>, "IEnumerable<TypeTransactionModel>");
        }

        [TesTransactionModelethod()]
        public void GetAllCount()
        {
            //Act
            IRestResponse response = restClient.Execute(TypeTransactionHelper.GetAll);
            IEnumerable<TypeTransactionModel> locationResponse = new JsonDeserializer().Deserialize<IEnumerable<TypeTransactionModel>>(response);
            // Assert
            Assert.AreEqual(locationResponse.Count(), 3);
        }
        #endregion
    }
}
