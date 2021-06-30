using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Other.DbFactory
{
    public class DbCategory: IDbCreator
    {
        public static void CreateDbIfNotExist()
        {
            using (IDbConnection db = new SqlConnection(DB.CONNECTION_STRING))
            {
                var v = db.Query<int?>($"SELECT OBJECT_ID (N'{DB.CATEGORY}', N'U')").FirstOrDefault();
                if (v == null)
                {
                    //Создаем таблицу
                    db.Query($@"CREATE TABLE {DB.CATEGORY}(
	                        [Id] [int] IDENTITY(1,1) NOT NULL,
                            [Name] [varchar](max) NULL,
                            [TypeId] [int] NULL,
	                        [CategoryId] [int] NULL
                        ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
                        );
                    //Заполняем категории
                    db.Query($@"INSERT INTO {DB.CATEGORY}
                               ([Name]
                               ,[TypeId]
                               ,[CategoryId])
                         VALUES
                               ('Работа', 1, null),
                               ('Инвестиции', 1, null),
                               ('Подарки', 1, null),
                               ('Автомобиль', 2, null),
                               ('Дом', 2, null),
                               ('Здоровье', 2, null),
                               ('Личные расходы', 2, null),
                               ('Одежда', 2, null),
                               ('Питание', 2, null),
                               ('Подарки', 2, null),
                               ('Праздники', 2, null),
                               ('Ребенок', 2, null),
                               ('Техника', 2, null),
                               ('Услуги', 2, null),
                               ('Инвестиции', 2, null),
                               ('Обучение', 2, null),
                               ('Другое', 3, null),
                               ('Зарплата', 1, 1),
                               ('Премия', 1, 1),
                               ('Вклад', 1, 2),
                               ('Дивиденды', 1, 2),
                               ('Вклад', 1, 2),
                               ('Другое', 1, 3),
                               ('Топливо', 2, 4),
                               ('Обслуживание', 2, 4),
                               ('Страховка', 2, 4),
                               ('Хозяйственные расходы', 2, 5),
                               ('Ремонт', 2, 5),
                               ('Мебель', 2, 5),
                               ('Лекарства', 2, 6),
                               ('Стоматология', 2, 6),
                               ('Больница', 2, 6),
                               ('Рестораны', 2, 9),
                               ('Продукты', 2, 9),
                               ('Фастфуд', 2, 9),
                               ('Родственники', 2, 10),
                               ('Друзья', 2, 10),
                               ('Коммунальные услуги', 2, 13),
                               ('Акции', 2, 14),
                               ('Облигации', 2, 14),
                               ('ETF', 2, 14),
                               ('Вклад', 2, 14)
                    ");
                }
            }
        }
    }
}
