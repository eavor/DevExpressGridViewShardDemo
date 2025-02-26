using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class SqlSugarHelper
    {
        private static SqlSugarClient _db;

        public static SqlSugarClient Db
        {
            get
            {
                if (_db == null)
                {
                    _db = new SqlSugarClient(new ConnectionConfig()
                    {
                        ConnectionString = "Server=.;Database=demo;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;",
                        DbType = DbType.SqlServer, // 设置数据库类型
                        IsAutoCloseConnection = true, // 自动释放数据务，默认false
                        InitKeyType = InitKeyType.Attribute // 从实体特性中读取主键自增列信息
                    });
                }
                return _db;
            }
        }
    }
}
