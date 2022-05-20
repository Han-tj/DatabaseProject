using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class DrugInformation
    {
        public string Medicine_ID { set; get; }
        public string Medicine_name { set; get; }
        public decimal Price { set; get; }
        public decimal Quantity { set; get; }
        public string Picture_url { set; get; }
    }
    public class ShoppingCart
    {
        public string Pati_ID { set; get; }
        public decimal Capacity { set; get; }
        public decimal Quantity { set; get; }
        public List<DrugInformation> Objects { set; get; }
        public static ShoppingCart ShowObject(string Pati_ID)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.Pati_ID = Pati_ID;
            cart.Quantity = 0;
            cart.Capacity = 1000;
            decimal quantity = 0;
            List<DrugInformation> inforList = new List<DrugInformation>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT Medicine_ID,Medicine_name,Price,Quantity,Picture_url FROM ((SHOPPING_CART NATURAL JOIN ADD_FORM ) NATURAL JOIN DRUG) WHERE Pati_ID = :Pati_ID",
                new OracleParameter(":Pati_ID",Pati_ID)
                );
            foreach(DataRow dr in dt.Rows)
            {
                inforList.Add(dr.DtToModel<DrugInformation>());
                quantity += dr.DtToModel<DrugInformation>().Quantity;
            }
            if (dt.Rows.Count > 0)
            {
                cart.Quantity = quantity;
                cart.Objects = inforList;
            }
            return cart;
        }
        public static int AddShoppingcart(string pati_id,string cart_id)
        {
            int capacity = 1000;
            int quantity = 0;
            return oracleHelper.ExecuteNonQuery("INSERT INTO SHOPPING_CART(Pati_ID,Shoppingcart_ID,Capacity,Quantity) VALUES(:Pati_ID,:Shoppingcart_ID,:Capacity,:Quantity)",
                new OracleParameter(":Pati_ID", pati_id),
                new OracleParameter(":Shoppingcart_ID", cart_id),
                new OracleParameter(":Capacity",capacity),
                new OracleParameter(":Quantity",quantity)
                );
        }
    }
}
