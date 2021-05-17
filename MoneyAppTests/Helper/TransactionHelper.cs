using MoneyApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAppAPITests.Helper
{
    public class TransactionHelper
    {
        // Костыль для DDT, т.к. DataRow принимает константы или typeOf
        public static Dictionary<string, IRestRequest> FakeRestRequest
        {
            get => new Dictionary<string, IRestRequest>
        {
            { "PutWithoutType",PutWithoutType},
            { "PutWithoutDate",PutWithoutDate},
            { "PutWithoutAmountIs0",PutWithoutAmountIs0},
        };
        }

        #region тестовые TransactionModel
        public static TransactionModel transaction = new TransactionModel() {Date=DateTime.Today, Type=new TypeTransactionModel() {Id=1, Type="Доход" }, Amount=100.4M, Description="hgf" };
        public static TransactionModel transactionTypeNotFound = new TransactionModel() { Date = DateTime.Today, Type = new TypeTransactionModel() { Id = -1, Type = "Доход" }, Amount = 100.4M, Description = "123" };
        public static TransactionModel transactionWithoutType = new TransactionModel() { Date = DateTime.Today, Type = null, Amount = 100.4M, Description = "123" };
        public static TransactionModel transactionWithoutDate = new TransactionModel() { Date = null, Type = new TypeTransactionModel() { Id = 1, Type = "Доход" }, Amount = 100.4M, Description = "123" };
        public static TransactionModel transactionAmountIs0 = new TransactionModel() { Date = DateTime.Today, Type = new TypeTransactionModel() { Id = 1, Type = "Доход" }, Amount = 0, Description = "123" };

        #endregion
        public static readonly RestRequest GetAll = new RestRequest("Transaction/All", Method.GET);
        public static readonly RestRequest Get0NotFound = new RestRequest("Transaction/Get/0", Method.GET);
        public static readonly RestRequest Get1Ok = new RestRequest("Transaction/Get/1", Method.GET);
        public static readonly RestRequest Delete0NotFound = new RestRequest("Transaction/Delete/0", Method.DELETE);
        public static readonly IRestRequest PostOk = Request("Transaction/Post", Method.POST, transaction);
        public static readonly IRestRequest PostTypeNotFound = Request("Transaction/Post", Method.POST, transactionTypeNotFound);
        public static readonly IRestRequest PostNotFound = Request("Transaction/Post", Method.POST, null);
        public static readonly IRestRequest PutWithoutType = Request("Transaction/PUT/1", Method.PUT, transactionWithoutType);
        public static readonly IRestRequest PutWithoutDate = Request("Transaction/PUT/1", Method.PUT, transactionWithoutDate);
        public static readonly IRestRequest PutWithoutAmountIs0 = Request("Transaction/PUT/1", Method.PUT, transactionAmountIs0);


        static IRestRequest Request(string route, Method method, TransactionModel transaction)
        {
            return new RestRequest(route, method).AddParameter("application/json",
                                                                    JsonConvert.SerializeObject(transaction),
                                                                    ParameterType.RequestBody);
        }
    }
}
