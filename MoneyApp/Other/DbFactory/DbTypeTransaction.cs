using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Other.DbFactory
{
    public class DbTypeTransaction: IDbCreator
    {
        public static new void CreateDbIfNotExist()
        {
            using (IDbConnection db = new SqlConnection(DB.CONNECTION_STRING))
            {
                var v = db.Query<int?>($"SELECT OBJECT_ID (N'{DB.TYPE_TRANSACTION}', N'U')").FirstOrDefault();
                if (v == null)
                {
                    throw new NotImplementedException();
                    //Создаем таблицу
                    db.Query($@"CREATE TABLE {DB.TYPE_TRANSACTION}(
	                        	[Id] [int] NULL,
	                            [Name] [varchar](max) NULL
                            ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
                        );
                    //Заполняем категории
                    db.Query($@"INSERT INTO {DB.TYPE_TRANSACTION}
                               (([Id]
                                ,[Name])
                         VALUES
                               (1, 'Доход'),
                               (2, 'Расход'),
                               (3, 'Перевод'),
                    ");
                }
            }
        }
    }
}
