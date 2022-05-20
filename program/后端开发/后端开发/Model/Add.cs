using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.CodeAnalysis.FindSymbols;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class Add
    {
        public string Medicine_ID { set; get; }
        public string Pati_ID { set; get; }
        public decimal Quantity { set; get; }
        public static Add Find(string Medicine_ID,string Pati_ID)
        {
            Add add = null;
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM ADD_FORM WHERE Medicine_ID = :Medicine_ID AND Pati_ID = :Pati_ID",
                new OracleParameter(":Medicine_ID", Medicine_ID),
                new OracleParameter(":Pati_ID", Pati_ID)
                );
            if(dt.Rows.Count > 0)
                add = dt.Rows[0].DtToModel<Add>();
            return add;
        }
        public static int AddDrug(string Medicine_ID,string Pati_ID,decimal quantity)
        {
            Add add = Find(Medicine_ID,Pati_ID);
            if (add != null)
            {
                add.Quantity += quantity;
                quantity = add.Quantity;
                if (add.Quantity > 0)
                {
                    oracleHelper.ExecuteNonQuery("DELETE FROM ADD_FORM WHERE Pati_ID = :Pati_ID AND Medicine_ID = :Medicine_ID",
                    new OracleParameter(":Pati_ID", Pati_ID),
                    new OracleParameter(":Medicine_ID", Medicine_ID)
                    );
                    oracleHelper.ExecuteNonQuery("INSERT INTO ADD_FORM(Medicine_ID,Pati_ID,Quantity) VALUES(:Medicine,:Pati_ID,:Quantity)",
                    new OracleParameter(":Medicine_ID", Medicine_ID),
                    new OracleParameter(":Pati_ID", Pati_ID),
                    new OracleParameter(":Quantity", quantity)
                    );
                    return 1;
                }
                else
                    return oracleHelper.ExecuteNonQuery("DELETE FROM ADD_FORM WHERE Pati_ID = :Pati_ID AND Medicine_ID = :Medicine_ID",
                    new OracleParameter(":Pati_ID", Pati_ID),
                    new OracleParameter(":Medicine_ID", Medicine_ID)
                    );
            }
            else
            {
                return oracleHelper.ExecuteNonQuery("INSERT INTO ADD_FORM(Medicine_ID,Pati_ID,Quantity) VALUES(:Medicine,:Pati_ID,:Quantity)",
                    new OracleParameter(":Medicine_ID",Medicine_ID),
                    new OracleParameter(":Pati_ID",Pati_ID),
                    new OracleParameter(":Quantity",quantity)
                    );
            }
        }
        public static int EmptyCart(string Pati_ID)
        {
            return oracleHelper.ExecuteNonQuery("DELETE FROM ADD_FORM WHERE Pati_ID = :Pati_ID",
                 new OracleParameter(":Pati_ID",Pati_ID)
                );
        }
    }
}
