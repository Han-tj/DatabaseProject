using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class Department
    {
        public string department { set; get; }
        public string Related_sickness { set; get; }
        public static Department Find(string name)
        {
            Department department = null;
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM DEPARTMENT WHERE Department = :Department",
                new OracleParameter(":Department", name)
                );
            if(dt.Rows.Count > 0)
                department = dt.Rows[0].DtToModel<Department>();
            return department;
        }
        public static List<Department> ListAll()
        {
            List<Department> list = new List<Department>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM DEPARTMENT");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr.DtToModel<Department>());
            }
            return list;
        }
    }
}
