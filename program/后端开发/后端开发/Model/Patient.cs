using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class Patient
    {
        public string Pati_ID { set; get; }
        public string Pati_name { set; get; }
        public string Password { set; get; }
        public string Tel { set; get; }
        public string Identification { set; get; }
        public string Sex { set; get; }
        public static Patient QueryByID(string ID)
        {
            Patient patient = null;
            DataTable dt = oracleHelper.ExecuteTable("SELECT *  FROM PATIENT WHERE Pati_ID=:Pati_ID",
                new OracleParameter(":Pati_ID",ID)
                );
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                patient = dr.DtToModel<Patient>();
            }
            return patient;
        }
        public static int AddPatient(string ID,string name,string password,string tel,string identification,string sex)
        {
            Patient patient = QueryByID(ID);
            if(patient != null)
            {
                patient.Pati_name = name;
                patient.Password = password;
                patient.Tel = tel;
                patient.Identification = identification;
                patient.Sex = sex;
                oracleHelper.ExecuteNonQuery("DELETE FROM PATIENT WHERE Pati_ID = :Pati_ID",
                new OracleParameter(":Pati_ID", patient.Pati_ID)
               );
                return oracleHelper.ExecuteNonQuery("INSERT INTO PATIENT(Pati_ID,Pati_name,Password,Tel,Identification,Sex) VALUES(:Pati_ID,:Pati_name,:Password,:Tel,:Identification,:Sex)",
                new OracleParameter(":Pati_ID", ID),
                new OracleParameter(":Pati_name", name),
                new OracleParameter(":Password", password),
                new OracleParameter(":Tel", tel),
                new OracleParameter(":Identification", identification),
                new OracleParameter(":Sex", sex)
                );
            }
            else
            {
                return oracleHelper.ExecuteNonQuery("INSERT INTO PATIENT(Pati_ID,Pati_name,Password,Tel,Identification,Sex) VALUES(:Pati_ID,:Pati_name,:Password,:Tel,:Identification,:Sex)",
                new OracleParameter(":Pati_ID", ID),
                new OracleParameter(":Pati_name", name),
                new OracleParameter(":Password", password),
                new OracleParameter(":Tel", tel),
                new OracleParameter(":Identification", identification),
                new OracleParameter(":Sex", sex)
                );
            }
        }
        public static int DelPatient(string ID)
        {
            return oracleHelper.ExecuteNonQuery("UPDATE PATIENT SET IS_DEL = 1 WHERE Pati_ID = :Pati_ID",
                new OracleParameter(":Pati_ID", ID)
                );
        }
    }
}
