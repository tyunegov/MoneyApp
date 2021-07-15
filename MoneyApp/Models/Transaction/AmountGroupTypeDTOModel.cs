using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Models
{
    public class AmountGroupTypeDTOModel
    {
        public TypeTransactionModel Type { get; set; }
        public decimal Amount { get; set; }
    }
}
