using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;
namespace 后端开发.Model
{
    public class Notice
    {
        public string Notice_ID { set; get; }
        public string Notice_name { set; get; }
        public string Content { set; get; }
        public string Time { set; get; }
        public static Notice GetNotice(string id)
        {
            Notice notice = null;
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM NOTICE WHERE Notice_ID = :Notice_ID",
                new OracleParameter(":Notice_ID", id)
                );
            if (dt.Rows.Count > 0)
                notice = dt.Rows[0].DtToModel<Notice>();
            return notice;
        }
        public static List<Notice> ListAll()
        {
            List<Notice> list = new List<Notice>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM NOTICE");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr.DtToModel<Notice>());
            }
            return list;
        }
    }
}
