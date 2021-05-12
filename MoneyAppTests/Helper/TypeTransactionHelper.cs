using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAppAPITests.Helper
{
    public class TypeTransactionHelper
    {
        public static readonly RestRequest GetAll = new RestRequest("Type/All", Method.GET);
    }
}
