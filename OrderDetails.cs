using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    [SugarTable("Orders")]
    public class OrderDetails
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime? Date { get; set; }
        public string CreateUser { get; set; }
        public string State { get; set; }
        public string Contract { get; set; }
        public string Customer { get; set; }
        public string Address { get; set; }
        public decimal Amount { get; set; }
        public string Way { get; set; }
        public string Remark { get; set; }
    }
}
