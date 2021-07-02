using Dapper;
using Microsoft.Data.SqlClient;
using MoneyAppDB.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyAppDb.Other.DbFactory
{
    public class DbTransaction: IDbCreator
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
	                        		[Id] [int] IDENTITY(1,1) NOT NULL,
	                                [Date] [date] NULL,
	                                [CategoryId] [int] NULL,
	                                [Amount] [money] NULL,
	                                [Description] [text] NULL
                                ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
                        );
                    //Заполняем категории
                    db.Query($@"INSERT INTO {DB.TYPE_TRANSACTION}
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
