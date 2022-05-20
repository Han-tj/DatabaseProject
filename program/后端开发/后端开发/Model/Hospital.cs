using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class Hospital
    {
        public string Hos_name { set; get; }
        public string Hos_Loc { set; get; }
        public string Tel { set; get; }
        public string Picture_url { set; get; }
        public string Introduction { set; get; }
        public static List<Hospital> ListAll()
        {
            List<Hospital> list = new List<Hospital>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT* FROM HOSPITAL");
            foreach (DataRow dr in dt.Rows)
                list.Add(dr.DtToModel<Hospital>());
            return list;
        }
        public static string Find(string hos_name)
        {
            Hospital hos = new Hospital();
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM HOSPITAL WHERE Hos_name = :Hos_name",
                new OracleParameter(":Hos_name", hos_name)
                );
            if (dt.Rows.Count > 0)
            {
                hos = dt.Rows[0].DtToModel<Hospital>();
                return hos.Hos_Loc;
            }
            else
            {
                return "";
            }
        }
        public static Hospital Query(string hos_name)
        {
            Hospital hos = null;
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM HOSPITAL WHERE Hos_name = :Hos_name",
                new OracleParameter(":Hos_name", hos_name)
                );
            if (dt.Rows.Count > 0)
            {
                hos = dt.Rows[0].DtToModel<Hospital>();
            }
            return hos;
        }
    }
}
