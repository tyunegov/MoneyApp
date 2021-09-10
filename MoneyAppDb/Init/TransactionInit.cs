using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;

namespace MoneyAppDb.Other.DbFactory
{
    public class TransactionInit: IDbInit
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
	                        		[Id] [int] IDENTITY(1,1) NOT NULL,
	                                [Date] [date] NULL,
	                                [CategoryId] [int] NULL,
	                                [Amount] [money] NULL,
	                                [Description] [text] NULL
                                ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
                        );
                    //Заполняем категории
                    db.Query($@"INSERT INTO {DBHelper.TYPE_TRANSACTION}
                               ([Date]
                               ,[CategoryId]
                               ,[Amount]
                               ,[Description])
                         VALUES
                               ('2021-01-01', 1, 2000, 'Первая запись')
                    ");
                }
            }
        }
    }
}
