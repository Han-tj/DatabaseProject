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
    public class Drug
    {
        public string Medicine_ID { set; get; }
        public string Medicine_Name { set; get; }
        public string Category { set; get; }
        public string Prescription_Type { set; get; }
        public string Price { set; get; }
        public string Adaption_Disease { set; get; }
        public string Inventory { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Picture_url { set; get; }
        public static Drug QueryByName(string name)
        {
            Drug drug = null;
            DataTable dt = oracleHelper.ExecuteTable("SELECT *  FROM DRUG WHERE Medicine_name = :Medicine_name",
               new OracleParameter(":Medicine_name",name)
               );
            if(dt.Rows.Count > 0)
                drug = dt.Rows[0].DtToModel<Drug>();
            return drug;
        }
        public static List<Drug> ListAll()
        {
            List<Drug> list = new List<Drug>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT *  FROM DRUG");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr.DtToModel<Drug>());
            }
            return list;
        }
        public static List<Drug> QueryByType(string category)
        {
            List<Drug> drugs = new List<Drug>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT Medicine_Name,Category,Price,Picture_url FROM DRUG WHERE Category = :Category",
                new OracleParameter(":Category", category)
                );
            foreach (DataRow dr in dt.Rows)
            {
                drugs.Add(dr.DtToModel<Drug>());
            }
            return drugs;
        }
        public static string AutoAdd(string pati_id,string pre_id)
        {
            List<DrugInfor> list = Include.GetIncludeDrug(pre_id);
            foreach(DrugInfor infor in list)
            {
                Drug drug = Drug.QueryByName(infor.Medicine_name);
                Add.AddDrug(drug.Medicine_ID, pati_id,decimal.Parse(infor.Quantity));
            }
            return "自动加购成功";
        }
    }
}
