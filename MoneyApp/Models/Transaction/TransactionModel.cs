using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Models.Transaction
{
    public class TransactionModel<C>
    {
            public int Id { get; set; }
            [Required]
            public DateTime? Date { get; set; }
            [Required]
            public C Category { get; set; }
            [Required]
            [Range(0.001, (double)7000000000M)]
            public decimal Amount { get; set; }
            public string Description { get; set; }
            [Required]
            public int? UserId { get; set; }
        }
    }