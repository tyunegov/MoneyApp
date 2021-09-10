using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MoneyApp.Other.State
{
    public class ErrorState
    {
        public string UserName { get; set; }
        public string Error { get; set; }
        public object Value { get; set; }
    }
}
