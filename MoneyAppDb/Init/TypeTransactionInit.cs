using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;

namespace MoneyAppDb.Other.DbFactory
{
    public class TypeTransactionInit: IDbInit
    {
        public static void CreateDbIfNotExist()
        {
            using (IDbConnection db = new SqlConnection(DBHelper.CONNECTION_STRING))
            {
                var v = db.Query<int?>($"SELECT OBJECT_ID (N'{DBHelper.TYPE_TRANSACTION}', N'U')").FirstOrDefault();
                if (v == null)
                {
                    throw new NotImplementedException();
                    //Создаем таблицу
                    db.Query($@"CREATE TABLE {DBHelper.TYPE_TRANSACTION}(
	                        	[Id] [int] NULL,
	                            [Name] [varchar](max) NULL
                            ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
                        );
                    //Заполняем категории
                    db.Query($@"INSERT INTO {DBHelper.TYPE_TRANSACTION}
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
