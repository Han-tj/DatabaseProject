using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class ElectronicPre
    {
        public string Prescription_ID { set; get; }
        public string Pati_ID { set; get; }
        public string Doctor_ID { set; get; }
        public string Department { set; get; }
        public DateTime  Prescription_Date { set; get; }
        public string Prescription_Content { set; get; }
        public static ElectronicPre Find(string Pati_ID,string Doctor_ID)
        {
            ElectronicPre pre = null;
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM ELECTRONIC_PRESCRIPTION WHERE Pati_ID = :Pati_ID AND Doctor_ID = :Doctor_ID",
                new OracleParameter(":Pati_ID",Pati_ID),
                new OracleParameter(":Doctor_ID",Doctor_ID)
                );
            if (dt.Rows.Count > 0)
            {
                pre = dt.Rows[0].DtToModel<ElectronicPre>();
            }
            else
            {
                pre = new ElectronicPre();
            }
            return pre;
        }
        public static int AddPre(string pre_ID,string Pati_ID,string Doctor_ID,string department,DateTime time,string content)
        {
            return oracleHelper.ExecuteNonQuery("INSERT INTO ELECTRONIC_PRESCRIPTION(Prescription_ID,Pati_ID,Doctor_ID,Department,Prescription_date,Prescription_content) VALUES(:Prescription_ID,:Pati_ID,:Doctor_ID,:Department,:Prescription_date,:Prescription_content)",
                new OracleParameter(":Prescription_ID", pre_ID),
                new OracleParameter(":Pati_ID", Pati_ID),
                new OracleParameter(":Doctor_ID", Doctor_ID),
                new OracleParameter(":Department", department),
                new OracleParameter(":Prescriptioin_date", time),
                new OracleParameter(":Prescription_content", content)
                );
        }
    }
    public class Record
    {
        public string Pati_ID { set; get; }
        public string Pati_name { set; get; }
        public DateTime Prescription_Date { set; get; }
        public string Prescription_Content { set; get; }
        public static List<Record> GetRecords(string ID)
        {
            List<Record> records = new List<Record>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT Pati_ID,Pati_name,Prescription_date,Prescription_content FROM (ELECTRONIC_PRESCRIPTION NATURAL JOIN PATIENT) WHERE Doctor_ID = :Doctor_ID",
                new OracleParameter(":Doctor_ID",ID)
                );
            foreach (DataRow dr in dt.Rows)
                records.Add(dr.DtToModel<Record>());
            return records;
        }
    }
}
