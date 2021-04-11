using MoneyApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAppAPITests.PageObject
{
    public static class TransactionPage
    {
        #region тестовые TransactionModel
        static TransactionModel transaction = new TransactionModel() {Date=DateTime.Today, Type=new TypeTransactionModel() {Id=1, Type="Доход" }, Amount=100.4M, Description="123" };
        static TransactionModel transactionTypeNotFound = new TransactionModel() { Date = DateTime.Today, Type = new TypeTransactionModel() { Id = -1, Type = "Доход" }, Amount = 100.4M, Description = "123" };
        #endregion
        public static readonly RestClient RestClient = new RestClient(@"https://localhost:44303/");
        public static readonly RestRequest GetAll = new RestRequest("Transaction/All", Method.GET);
        public static readonly RestRequest Get0NotFound = new RestRequest("Transaction/Get/0", Method.GET);
        public static readonly RestRequest Get1Ok = new RestRequest("Transaction/Get/1", Method.GET);
        public static readonly RestRequest Delete0NotFound = new RestRequest("Transaction/Delete/0", Method.DELETE);
        public static readonly IRestRequest PostNotFound = new RestRequest("Transaction/Post", Method.POST)
                                                             .AddParameter("application/json", JsonConvert.SerializeObject(null), ParameterType.RequestBody);
        public static readonly IRestRequest PostOk = new RestRequest("Transaction/Post", Method.POST)
                                                     .AddParameter("application/json", JsonConvert.SerializeObject(transaction), ParameterType.RequestBody);
        public static readonly IRestRequest PostTypeNotFound = new RestRequest("Transaction/Post", Method.POST)
                                                            .AddParameter("application/json", JsonConvert.SerializeObject(transactionTypeNotFound), ParameterType.RequestBody);

    }
}
