using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class Administrator
    {
        public string Admin_ID { set; get; }
        public static int AuditPatiApp(string req_number, string Admin_ID)
        {
            ApplicationFromPati form = ApplicationFromPati.Find(req_number);
            return oracleHelper.ExecuteNonQuery("UPDATE APPLICATION_FORM_PATI SET Admin_ID = :Admin_ID WHERE Requisition_number = :Requisition_number",
                new OracleParameter(":Admin_ID", Admin_ID),
                new OracleParameter(":Requisition_number", req_number)
                );
        }
        public static int AuditDocApp(string req_number, string Admin_ID)
        {
            ApplicationFromDoc form = ApplicationFromDoc.Find(req_number);
            return oracleHelper.ExecuteNonQuery("UPDATE APPLICATION_FORM_DOC SET Admin_ID = :Admin_ID WHERE Requisition_number = :Requisition_number",
                new OracleParameter(":Admin_ID", Admin_ID),
                new OracleParameter(":Requisition_number", req_number)
                );
        }
        public static int AuditReport(string report_number,string Admin_ID)
        {
            ReportForm report = ReportForm.Find(report_number);
            return oracleHelper.ExecuteNonQuery("UPDATE REPORT_FORM SET Admin_ID = :Admin_ID WHERE Report_number = :Report_number",
                new OracleParameter(":Admin_ID", Admin_ID),
                new OracleParameter(":Report_number", report_number)
                );
        }
        public static int PostNotice(string noticeID,string noticeName,string content,string time)
        {
            return oracleHelper.ExecuteNonQuery("INSERT INTO NOTICE(Notice_ID,Notice_name,Content,Time) VALUES(:Notice_ID,:Notice_name,:Content,:Time)",
                new OracleParameter(":Notice_ID", noticeID),
                new OracleParameter(":Notice_name", noticeName),
                new OracleParameter(":Content", content),
                new OracleParameter(":Time", time)
                );
        }
        public static int DeleteNotice(string ID)
        {
            return oracleHelper.ExecuteNonQuery("DELETE FROM NOTICE WHERE Notice_ID = :Notice_ID",
                new OracleParameter(":Notice_ID",ID)
                );
        }
    }
}
