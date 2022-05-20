using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class ReportForm
    {
        public string Report_Number { set; get; }
        public string Admin_ID { set; get; }
        public string Pati_ID { set; get; }
        public string Doctor_ID { set; get; }
        public DateTime Report_Time { set; get; }
        public string Report_Content { set; get; }
        public static ReportForm Find(string report_number)
        {
            ReportForm report = null;
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM REPORT_FORM WHERE Report_number = :Report_number",
                new OracleParameter(":Report_number", report_number)
                );
            if(dt.Rows.Count > 0)
                report = dt.Rows[0].DtToModel<ReportForm>();
            return report;
        }
        public static List<ReportForm> listAll()
        {
            List<ReportForm> list = new List<ReportForm>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM REPORT_FORM");
            foreach(DataRow dr in dt.Rows)
                list.Add(dr.DtToModel<ReportForm>());
            return list;
        }
        public static int AddReport(string report_number,string pati_id,string doctor_id,DateTime time,string content)
        {
            string Admin_ID = "0";
            return oracleHelper.ExecuteNonQuery("INSERT INTO REPORT_FORM(Report_number,Admin_ID,Pati_ID,Doctor_ID,Report_time,Report_content) VALUES(:Report_number,:Admin_ID,:Pati_ID,:Doctor_ID,:Report_time,:Report_content)",
                 new OracleParameter(":Report_number", report_number),
                 new OracleParameter(":Admin_ID",Admin_ID),
                 new OracleParameter(":Pati_ID", pati_id),
                 new OracleParameter(":Doctor_ID",doctor_id),
                 new OracleParameter(":Report_time",time),
                 new OracleParameter(":Report_content",content)
                );
        }
        public static List<ReportForm> GetReportList()
        {
            List<ReportForm> list = new List<ReportForm>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT Report_number,Pati_ID,Doctor_ID,Report_time FROM REPORT_FORM");
            foreach (DataRow dr in dt.Rows)
                list.Add(dr.DtToModel<ReportForm>());
            return list;
        }
    }
}
