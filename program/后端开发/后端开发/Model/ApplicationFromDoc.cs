using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class ApplicationFromDoc
    {
        public string Requisition_Number { set; get; }
        public string Admin_ID { set; get; }
        public string Proposer_ID { set; get; }
        public string Working_Age { set; get; }
        public string Title { set; get; }
        public string Hos_name { set; get; }
        public string Department { set; get; }
        public string Introduction { set; get; }
        public string Status { set; get; }
        public static ApplicationFromDoc Find(string req_number)
        {
            ApplicationFromDoc form = null;
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM APPLICATION_FORM_DOC WHERE Requisition_number = :Requisition_number",
                new OracleParameter(":Requisition_number", req_number)
                );
            if (dt.Rows.Count > 0)
                form = dt.Rows[0].DtToModel<ApplicationFromDoc>();
            return form;
        }
        public static int AddApp(string number,string ID,string workingAge,string hosName,string department,string introduction, string status)
        {
            string Admin_ID = "0";
            return oracleHelper.ExecuteNonQuery("INSERT INTO APPLICATION_FORM_DOC(Requisition_number,Admin_ID,Proposer_ID,Working_age,Hos_name,Department,Introduction,Status) VALUES(:Requisition_number,:Admin_ID,:Proposer_ID,:Working_age,:Hos_name,:Department,:Introduction,:Status)",
                new OracleParameter(":Requisition_number", number),
                new OracleParameter(":Admin_ID",Admin_ID),
                new OracleParameter(":Proposer_ID",ID),
                new OracleParameter(":Working_age",workingAge),
                new OracleParameter(":Hos_name",hosName),
                new OracleParameter(":Department",department),
                new OracleParameter(":Introduction",introduction),
                new OracleParameter(":Status",status)
                );
        }
        public static List<ApplicationFromDoc> GetAppList()
        {
            List<ApplicationFromDoc> list = new List<ApplicationFromDoc>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM APPLICATION_FORM_DOC");
            foreach (DataRow dr in dt.Rows)
                list.Add(dr.DtToModel<ApplicationFromDoc>());
            return list;
        }
    }
}
