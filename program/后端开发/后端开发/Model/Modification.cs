using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class Modification
    {
        public string Doctor_ID { set; get; }
        public string Disease_Name { set; get; }
        public static Modification Find(string id,string name)
        {
            Modification mod = null;
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM MODIFICATION WHERE Doctor_ID = :Doctor_ID AND Disease_name = :Disease_name",
                  new OracleParameter(":Doctor_ID", id),
                new OracleParameter(":Disease_name", name)
                );
            if(dt.Rows.Count > 0)
                mod = dt.Rows[0].DtToModel<Modification>();
            return mod;
        }
        public static int AddMod(string ID,string name)
        {
            Modification mod = Find(ID, name);
            if (mod != null)
                return 0;
            else
                return oracleHelper.ExecuteNonQuery("INSERT INTO MODIFICATION(Doctor_ID,Disease_name) VALUES(:Doctor_ID,:DiseaseName)",
                    new OracleParameter(":Doctor_ID",ID),
                    new OracleParameter(":Disease_name",name)
                    );
        }
    }
}
