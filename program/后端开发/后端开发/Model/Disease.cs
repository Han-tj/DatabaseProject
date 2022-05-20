using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class Disease
    {
        public string Disease_Name { set; get; }
        public string Pathogeny { set; get; }
        public string Symptoms { set; get; }
        public string Complication { set; get; }
        public string Medication { set; get; }
        public string Introduction { set; get; }
        public static Disease QueryByname(string name)
        {
            Disease disease = null;
            DataTable dt = oracleHelper.ExecuteTable("SELECT *  FROM DISEASE WHERE Disease_name=:Disease_name",
                new OracleParameter(":Disease_name", name)
                );
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                disease = dr.DtToModel<Disease>();
            }
            return disease;
        }
        public static int AddDisease(string name, string pathogeny, string symptoms, string complication, string medication,string introduction)
        {
            Disease disease = QueryByname(name);
            if(disease != null)
            {
                return oracleHelper.ExecuteNonQuery("UPDATE DISEASE SET Disease_name = :Disease_name,Pathogeny = :Pathogeny,Symptoms = :Symptoms,Complication = :Complication,Medication = :Medication,Introduction = :Introduction WHERE Disease_name = :Disease_name",
                    new OracleParameter(":Disease_name", name),
                    new OracleParameter(":Pathogeny", pathogeny),
                    new OracleParameter(":Symptoms", symptoms),
                    new OracleParameter(":Complication",complication),
                    new OracleParameter(":Medication",medication),
                    new OracleParameter(":Introduction",introduction)
                    );
            }
            else
            {
                return oracleHelper.ExecuteNonQuery("INSERT INTO DISEASE(Disease_name,Pathogeny,Symptoms,Complication,Medication,Introduction) VALUE(:Disease_name,:Pathogeny,:Symptoms,:Complication,:Medication,:Introduction)",
                    new OracleParameter(":Disease_name", name),
                    new OracleParameter(":Pathogeny", pathogeny),
                    new OracleParameter(":Symptoms", symptoms),
                    new OracleParameter(":Complication", complication),
                    new OracleParameter(":Medication", medication),
                    new OracleParameter(":Introduction",introduction)
                    );
            }
        }
        public static int DeleteDisease(string name)
        {
            return oracleHelper.ExecuteNonQuery("DELETE FROM DISEASE WHERE Diease_name = :Disease_name",
                new OracleParameter(":Disease_name", name)
                );
        }
        public static List<Disease> ListAll()
        {
            List<Disease> list = new List<Disease>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM DISEASE");
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(dr.DtToModel<Disease>());
            }
            return list;
        }
    }
}
