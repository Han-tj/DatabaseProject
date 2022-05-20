using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class DepartmentToHos
    {
        public string Hos_Name { set; get; }
        public string Department { set; get; }
        public static List<DepartmentToHos> ListAll()
        {
            List<DepartmentToHos> list = new List<DepartmentToHos>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM DEPARTMENT_BELONGS_TO_HOSPITAL");
            foreach (DataRow dr in dt.Rows)
                list.Add(dr.DtToModel<DepartmentToHos>());
            return list;
        }
    }
}
