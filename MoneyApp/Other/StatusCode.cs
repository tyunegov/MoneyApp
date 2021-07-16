using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Other
{
    public static class StatusCode
    {
        public static string TRANSACTION_NOT_FOUND = "Транзакция не найдена";
        public static string CATEGORY_NOT_FOUND = "Категория не найдена";
        public static string STARTDATE_LATER_THAN_ENDDATE = "Дата начала отчетного периода не может быть больше даты окончания отчетного периода";
        public static string FAILED_TO_WRITE_TRANSACTION = "Ошибка выполнения записи";
        public static string SUCCESS = "Операция выполнена успешно";
        public static string TRANSACTION_NOT_FOUND_BY_PERIOD = "Не найдено транзакций за данный период";
        public static string LOGIN_NOT_UNIQUE = "Данный логин уже зарегистрирован в системе";
        public static string INVALID_LOGIN_OR_PASSWORD = "Неправильный логин или пароль";
    }
}