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
        public static readonly RestClient RestClient = new RestClient(@"https://localhost:44303/");
        public static readonly RestRequest GetAll = new RestRequest("Transaction/All", Method.GET);
    }
}
