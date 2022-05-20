using Microsoft.AspNetCore.StaticFiles;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class Pati_infor
    {
        public string Pati_ID { set; get; }
        public string Height { set; get; }
        public string Weight { set; get; }
        public string BMI { set; get; } 
        public string Heart_rate { set; get; }
        public string Systolic_pressure { set; get; }
        public string Diastolic_pressure { set; get; }
       
        public static Pati_infor Find(string ID)
        {
            Pati_infor infor = null;
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM PATI_INFOR WHERE Pati_ID = :Pati_ID",
                new OracleParameter(":Pati_ID", ID)
                );
            if(dt.Rows.Count > 0)
                infor = dt.Rows[0].DtToModel<Pati_infor>();
            return infor;
        }
        public static int AddInfor(string id,string height,string weight,string BMI,string heartRate,string systolic_pressure,string diastolic_pressure)
        {
            Pati_infor infor = Find(id);
            if (infor != null)
                return oracleHelper.ExecuteNonQuery("UPDATE PATI_INFOR SET Height = :Height,Weight = :Weight,BMI = :BMI,Heart_rate = :Heart_rate,Systolic_pressure = :Systolic_pressure,Diastolic_pressure = :Diastolic_pressure WHERE Pati_ID = :Pati_ID",
                    new OracleParameter(":Pati_ID", id),
                    new OracleParameter(":Height", height),
                    new OracleParameter(":Weight", weight),
                    new OracleParameter(":BMI", BMI),
                    new OracleParameter(":Heart_rate", heartRate),
                    new OracleParameter(":Systolic_pressure", systolic_pressure),
                    new OracleParameter(":Diastolic_pressure",diastolic_pressure)
                    );
            else
                return oracleHelper.ExecuteNonQuery("INSERT INTO PATI_INFOR(Pati_ID,Height,Weight,BMI,Heart_rate,Systolic_pressure,Diastolic_pressure) VALUES(:Pati_ID,:Height,:Weight,:BMI,:Heart_rate,:Systolic_pressure,:Diastolic_pressure)",
                    new OracleParameter(":Pati_ID", id),
                    new OracleParameter(":Height", height),
                    new OracleParameter(":Weight", weight),
                    new OracleParameter(":BMI", BMI),
                    new OracleParameter(":Heart_rate", heartRate),
                    new OracleParameter(":Systolic_pressure", systolic_pressure),
                    new OracleParameter(":Diastolic_pressure", diastolic_pressure)
                    );
        }
    }
}
