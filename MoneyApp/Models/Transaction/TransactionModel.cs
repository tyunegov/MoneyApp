﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyApp.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        public CategoryModel Category { get; set; }
        [Required]
        [Range(0.001, (double)7000000000M)]
        public decimal Amount { get; set; }
        public string Description { get; set; }

    }
}