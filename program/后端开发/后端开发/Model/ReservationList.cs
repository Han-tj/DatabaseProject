using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class ReservationList
    {
        public string Reservation_Number { set; get; }
        public string Doctor_ID { set; get; }
        public string Doctor_name { set; get; }
        public string Pati_ID { set; get; }
        public string Pati_name { set; get; }
        public DateTime Reservation_Time { set; get; }
        public string Status { set; get; }
        public static List<ReservationList> ListAll(string Pati_ID)
        {
            List<ReservationList> list = new List<ReservationList>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT Reservation_number, Doctor_ID, Doctor_name, Pati_ID, Pati_name, Reservation_Time, Status FROM ((PATIENT NATURAL JOIN RESERVATION_FORM) JOIN DOCTOR USING (Doctor_ID)) WHERE Pati_ID = :Pati_ID",
                new OracleParameter(":Pati_ID", Pati_ID)
                );
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr.DtToModel<ReservationList>());
            }
            return list;
        }
        public static int AddReservation(string reservation_number, string pati_id, string doctor_id, DateTime time, string status)
        {
            return oracleHelper.ExecuteNonQuery("INSERT INTO RESERVATION_FORM(Reservation_number,Doctor_ID,Pati_ID,Reservation_time,Status) VALUES(:Reservation_number,:Doctor_ID,:Pati_ID,:Reservation_time,:Status)",
                new OracleParameter(":Reservation_number", reservation_number),
                new OracleParameter(":Doctor_ID", doctor_id),
                new OracleParameter(":Pati_ID", pati_id),
                new OracleParameter(":Reservation_time", time),
                new OracleParameter(":Status", status)
                );
        }
        public static List<ReservationList> GetReservationLists(string doctor_id)
        {
            List<ReservationList> list = new List<ReservationList>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT Reservation_number, Doctor_ID, Doctor_name, Pati_ID, Pati_name, Reservation_Time, Status FROM ((PATIENT NATURAL JOIN RESERVATION_FORM) JOIN DOCTOR USING (Doctor_ID)) WHERE Doctor_ID = :Doctor_ID",
                new OracleParameter(":Doctor_ID", doctor_id)
                );
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr.DtToModel<ReservationList>());
            }
            return list;
        }
        public static int UpdateReservation(string reservation_number, string status)
        {
            switch (status)
            {
                case "0":
                    {
                        return oracleHelper.ExecuteNonQuery("UPDATE RESERVATION_FORM SET Status = 0 WHERE Reservation_number =:Reservation_number",
              new OracleParameter(":Reservation_number", reservation_number)
              );
                    }
                case "1":
                    {
                        return oracleHelper.ExecuteNonQuery("UPDATE RESERVATION_FORM SET Status = 1 WHERE Reservation_number =:Reservation_number",
               new OracleParameter(":Reservation_number", reservation_number)
               );
                    }
                case "2":
                    {
                        return oracleHelper.ExecuteNonQuery("UPDATE RESERVATION_FORM SET Status = 2 WHERE Reservation_number =:Reservation_number",
               new OracleParameter(":Reservation_number", reservation_number)
               );
                    }
                case "3":
                    {
                        return oracleHelper.ExecuteNonQuery("UPDATE RESERVATION_FORM SET Status = 3 WHERE Reservation_number =:Reservation_number",
               new OracleParameter(":Reservation_number", reservation_number)
               );
                    }
                case "4":
                    {
                        return oracleHelper.ExecuteNonQuery("UPDATE RESERVATION_FORM SET Status = 4 WHERE Reservation_number =:Reservation_number",
               new OracleParameter(":Reservation_number", reservation_number)
               );
                    }

            }
            return 0;
        }
    }
}
