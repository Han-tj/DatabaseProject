using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class ApplicationFromPati
    {
        public string Requisition_Number { set; get; }
        public string Admin_ID { set; get; }
        public string Proposer_ID { set; get; }
        public DateTime Requisition_Time { set; get; }
        public string Requisition_Content { set; get; }
        public static ApplicationFromPati Find(string req_number)
        {
            ApplicationFromPati form = null;
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM APPLICATION_FORM_PATI WHERE Requisition_number = :Requisition_number",
                new OracleParameter(":Requisition_number", req_number)
                );
            if (dt.Rows.Count > 0)
                form = dt.Rows[0].DtToModel<ApplicationFromPati>();
            return form;
        }
        public static int AddApp(string number, string ID, DateTime time, string content)
        {
            string Admin_ID = "0";
            return oracleHelper.ExecuteNonQuery("INSERT INTO APPLICATION_FORM_PATI(Requisition_number,Admin_ID,Proposer_ID,Requisition_time,Requisition_content) VALUES(:Requisition_number,:Admin_ID,:Proposer_ID,:Requisition_time,:Requisition_content)",
                new OracleParameter(":Requisition_number", number),
                new OracleParameter(":Admin_ID",Admin_ID),
                new OracleParameter(":Proposer_ID", ID),
                new OracleParameter(":Requisition_time", time),
                new OracleParameter(":Requisition_content", content)
                );
        }
        public static List<ApplicationFromPati> GetAppList()
        {
            List<ApplicationFromPati> list = new List<ApplicationFromPati>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT Requisition_number,Proposer_ID,Requisition_time FROM APPLICATION_FORM_PATI");
            foreach (DataRow dr in dt.Rows)
                list.Add(dr.DtToModel<ApplicationFromPati>());
            return list;
        }
    }
}
