using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class RatingForm
    {
        public string Pati_ID { set; get; }
        public string EvaluationTime { set; get; }
        public string EvaluationContent { set; get; }
        public static List<RatingForm> ListAll(string doctor_id)
        {
            List<RatingForm> forms = new List<RatingForm>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT Pati_ID,Evaluation_time,Evaluation_content FROM RATING_FORM WHERE Doctor_ID = :Doctor_ID",
                new OracleParameter(":Doctor_ID", doctor_id)
                );
            foreach (DataRow dr in dt.Rows)
                forms.Add(dr.DtToModel<RatingForm>());
            return forms;
        }
        public static int AddEvaluation(string number,string Pati_ID,string Doctor_ID,string time,string content)
        {
            return oracleHelper.ExecuteNonQuery("INSERT INTO RATING_FORM(Evaluation_number,Pati_ID,Doctor_ID,Evaluation_time,Evaluation_content) VALUES(:Evaluation_number,:Pati_ID,:Doctor_ID,:Evaluation_time,:Evaluation_content)",
                new OracleParameter(":Evaluation_number",number),
                new OracleParameter(":Pati_ID",Pati_ID),
                new OracleParameter(":Doctor_ID",Doctor_ID),
                new OracleParameter(":Evaluation_time",time),
                new OracleParameter(":Evaluation_content",content)
                );
        }
    }
}
