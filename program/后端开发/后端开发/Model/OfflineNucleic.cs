using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class OfflineNucleic
    {
        public string Pati_ID { set; get; }
        public string Hos_name { set; get; }
        public DateTime Time { set; get; }
        public string Status { set; get; }
        public string Hos_loc { set; get; }
        public static List<OfflineNucleic> GetRecord(string ID)
        {
            List<OfflineNucleic> list = new List<OfflineNucleic>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM (OFFLINE_NUCLEIC NATURAL JOIN HOSPITAL) WHERE PATI_ID = :PATI_ID",
                new OracleParameter(":PATI_ID", ID)
                );
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(dr.DtToModel<OfflineNucleic>());
            }
            return list;
        }
        public static int PostNucleicApp(string id,string hosName,DateTime time,string status)
        {
            return oracleHelper.ExecuteNonQuery("INSERT INTO OFFLINE_NUCLEIC(Pati_ID,Hos_name,Time,Status) VALUES(:Pati_ID,:Hos_name,:Time,:Status)",
                new OracleParameter(":Pati_ID", id),
                new OracleParameter(":Hos_name", hosName),
                new OracleParameter(":Time", time),
                new OracleParameter(":Status",status)
                );
        }
        public static int RectifyNucleicApp(string id,DateTime time, string status)
        {
            switch (status)
            {
                case "0":
                    {
                        return oracleHelper.ExecuteNonQuery("UPDATE OFFLINE_NUCLEIC SET Status = 0 WHERE Pati_ID = :Pati_ID AND Time = :Time",
              new OracleParameter(":Pati_ID", id),
              new OracleParameter(":Time",time)
              );
                    }
                case "1":
                    {
                        return oracleHelper.ExecuteNonQuery("UPDATE OFFLINE_NUCLEIC SET Status = 1 WHERE Pati_ID = :Pati_ID AND Time = :Time",
               new OracleParameter(":Pati_ID", id),
               new OracleParameter(":Time", time)
               );
                    }
                case "2":
                    {
                        return oracleHelper.ExecuteNonQuery("UPDATE OFFLINE_NUCLEIC SET Status = 2 WHERE Pati_ID = :Pati_ID AND Time = :Time",
               new OracleParameter(":Pati_ID", id),
               new OracleParameter(":Time", time)
               );
                    }
                case "3":
                    {
                        return oracleHelper.ExecuteNonQuery("UPDATE OFFLINE_NUCLEIC SET Status = 3 WHERE Pati_ID = :Pati_ID AND Time = :Time",
               new OracleParameter(":Pati_ID", id),
               new OracleParameter(":Time", time)
               );
                    }
            }
            return 0;
        }
    }
}