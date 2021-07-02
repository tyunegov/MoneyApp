using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Other
{
    public class StatusCode : ControllerBase
    {
        public static string TRANSACTION_NOT_FOUND = "Транзакция не найдена";
        public static string CATEGORY_NOT_FOUND = "Категория не найдена";
        public static string STARTDATE_ID_GREATER_THAN_ENDDATE = "Дата начала отчетного периода не может быть больше даты окончания отчетного периода";
        public static string FAILED_TO_WRITE_TRANSACTION = "Ошибка выполнения транзакции";
        public static string SUCCESS = "Запрос выполнен успешно";
        public static string TRANSACTION_NOT_FOUND_BY_PERIOD = "No transactions found for this period";

    }
}