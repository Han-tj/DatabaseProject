using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class Include
    {
        public string Medicine_name { set; get; }
        public string Prescription_ID { set; get; }
        public string Quantity { set; get; }
        public string Content { set; get; }
        public static int AddInclude(string m_name,string p_id,string quantity,string content)
        {
            return oracleHelper.ExecuteNonQuery("INSERT INTO INCLUDE_FORM(Medicine_name,Prescription_ID,Quantity,Content) VALUES(:Medicine_name,:Prescription_ID,:Quantity,:Content)",
                new OracleParameter(":Medicine_name", m_name),
                new OracleParameter(":Prescription_ID", p_id),
                new OracleParameter(":Quantity",quantity),
                new OracleParameter(":Content",content)
                );
        }
        public static List<Include> GetIncludeList(string id)
        {
            List<Include> list = new List<Include>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM INCLUDE_FORM WHERE Prescription_ID = :Prescription_ID",
                new OracleParameter(":Prescription_ID", id)
                );
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(dr.DtToModel<Include>());
            }
            return list;
        }
        public static List<DrugInfor> GetIncludeDrug(string pre_id)
        {
            List<DrugInfor> list = new List<DrugInfor>();
              DataTable dt = oracleHelper.ExecuteTable("SELECT Medicine_name,Quantity FROM INCLUDE_FORM WHERE Prescription_ID = :Prescription_ID",
                new OracleParameter(":Prescription_ID", pre_id)
                );
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(dr.DtToModel<DrugInfor>());
            }
            return list;
        }
    }
    public class DrugInfor
    {
        public string Medicine_name { set; get; }
        public string Quantity { set; get; }
    }
}
