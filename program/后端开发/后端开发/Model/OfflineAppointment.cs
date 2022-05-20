using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class OfflineAppointment
    {
        public string Status { set; get; }
        public string Pati_ID { set; get; }
        public string Hos_name { set; get; }
        public string Department { set; get; }
        public DateTime Time { set; get; }
        public string Hos_loc { set; get; }

        public static int AddAppointment(string pati_id,string hos_name,string department,DateTime time)
        {
            decimal status = 1;
            return oracleHelper.ExecuteNonQuery("INSERT INTO OFFLINE_APPOINTMENT(Status,Pati_ID,Hos_name,Department,Time) VALUES(:Status,:Pati_ID,:Hos_name,:Department,:Time)",
                new OracleParameter(":Status",status),
                new OracleParameter(":Pati_ID",pati_id),
                new OracleParameter(":Hos_name",hos_name),
                new OracleParameter(":Department",department),
                new OracleParameter(":Time",time)
                );
        }
        public static List<OfflineAppointment> ListAll(string id)
        {
            List<OfflineAppointment> list = new List<OfflineAppointment>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM (OFFLINE_APPOINTMENT NATURAL JOIN HOSPITAL) WHERE Pati_ID = :Pati_ID",
                new OracleParameter(":Pati_ID",id)
                );
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(dr.DtToModel<OfflineAppointment>());
            }
            return list;
        }
        public static int RectifyOfflineApp(string id,DateTime time,string status)
        {
            switch (status)
            {
                case "0":
                    {
                        return oracleHelper.ExecuteNonQuery("UPDATE OFFLINE_APPOINTMENT SET Status = 0 WHERE Pati_ID = :Pati_ID AND Time = :Time",
              new OracleParameter(":Pati_ID", id),
              new OracleParameter(":Time", time)
              );
                    }
                case "1":
                    {
                        return oracleHelper.ExecuteNonQuery("UPDATE OFFLINE_APPOINTMENT SET Status = 1 WHERE Pati_ID = :Pati_ID AND Time = :Time",
               new OracleParameter(":Pati_ID", id),
               new OracleParameter(":Time", time)
               );
                    }
                case "2":
                    {
                        return oracleHelper.ExecuteNonQuery("UPDATE OFFLINE_APPOINTMENT SET Status = 2 WHERE Pati_ID = :Pati_ID AND Time = :Time",
               new OracleParameter(":Pati_ID", id),
               new OracleParameter(":Time", time)
               );
                    }
                case "3":
                    {
                        return oracleHelper.ExecuteNonQuery("UPDATE OFFLINE_APPOINTMENT SET Status = 3 WHERE Pati_ID = :Pati_ID AND Time = :Time",
               new OracleParameter(":Pati_ID", id),
               new OracleParameter(":Time", time)
               );
                    }
            }
            return 0;
        }
           
    }
}