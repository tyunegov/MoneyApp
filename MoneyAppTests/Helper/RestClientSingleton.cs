using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAppAPITests.Helper
{
    public static class RestClientSingleton
    {
        public static readonly RestClient RestClient = new RestClient(@"http://192.168.0.43/");
    }
}
