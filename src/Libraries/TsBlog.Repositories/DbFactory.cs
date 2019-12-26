using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace TsBlog.Repositories
{
    public    class DbFactory
    {
        public static SqlSugarClient GetSqlSugarClient()
        {
            return new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = Config.ConnectionString,  // mandatory
                DbType = DbType.MySql, // mandatory
                IsAutoCloseConnection = true, // default false
                InitKeyType = InitKeyType.Attribute
            });
        }
    }
}
