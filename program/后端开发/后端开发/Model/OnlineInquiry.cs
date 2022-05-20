using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class OnlineInquiry
    {
        public string Pati_ID { set; get; }
        public string Doctor_ID { set; get; }
        public string Time { set; get; }
        public string Department { set; get; }
        public string InquiryContent { set; get; }
        public string Status { set; get; }
        public static int AddInquiry(string pati_id,string doctor_id,string time,string department,string content,string status)
        {
            return oracleHelper.ExecuteNonQuery("INSERT INTO ONLINE_INQUIRY(Pati_ID,Doctor_ID,Time,Department,Inquiry_content,status) VALUE(:Pati_ID,:Doctor_ID,:Time,:Department,:Inquiry_content,:status)",
                new OracleParameter(":Pati_ID",pati_id),
                new OracleParameter(":Doctor_ID",doctor_id),
                new OracleParameter(":Time",time),
                new OracleParameter(":Department",department),
                new OracleParameter(":Inquiry_content",content),
                new OracleParameter(":Status",status)
                );
        }
        public static OnlineInquiry Find(string pati_id, string doctor_id, string time)
        {
            OnlineInquiry inquiry = null;
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM ONLINE_INQUIRY WHERE Pati_ID = :Pati_ID AND Doctor_ID = :Doctor_ID AND Time = :Time",
                new OracleParameter(":Pati_ID", pati_id),
                new OracleParameter(":Doctor_ID", doctor_id),
                new OracleParameter(":Time", time)
                );
            inquiry = dt.Rows[0].DtToModel<OnlineInquiry>();
            return inquiry;
        }
        public static int RectifyOnlineInqury(string pati_id,string doctor_id,string status)
        {
            return oracleHelper.ExecuteNonQuery("UPDATE ONLINE_INQURY SET Status = :Status WHERE Pati_id = :Pati_id AND Doctor_ID = :Doctor_ID",
                new OracleParameter(":Status", status),
                new OracleParameter(":Pati_id", pati_id),
                new OracleParameter(":Doctor_ID", doctor_id)
                );
        }
    }
}
