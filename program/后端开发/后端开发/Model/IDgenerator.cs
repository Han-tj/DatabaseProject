using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class IDgenerator
    {
        public static string Pati_IDgenerator()
        {
            Random ro = new Random();
            int iResult;
            int iUp = 99999999;
            int iDown = 10000000;
            iResult = ro.Next(iDown, iUp);
            return iResult.ToString();
        }
        public static string Doctor_IDgenerator()
        {
            Random ro = new Random();
            int iResult;
            int iUp = 999;
            int iDown = 100;
            iResult = ro.Next(iDown, iUp);
            return iResult.ToString();
        }
        public static string Cart_IDgenerator(string ID)
        {
            int iResult = int.Parse(ID);
            iResult = (iResult * 10 + 1)%1000;
            return iResult.ToString();
        }
        public static string Pre_IDgenerator()
        {
            Random ro = new Random();
            int iResult;
            int iUp = 99999;
            int iDown = 10000;
            iResult = ro.Next(iDown, iUp);
            return iResult.ToString();
        }
        public static string App_IDgenerator()
        {
            Random ro = new Random();
            int iResult;
            int iUp = 9999999;
            int iDown = 1000000;
            iResult = ro.Next(iDown, iUp);
            return iResult.ToString();
        }
        public static string Report_IDgenerator()
        {
            Random ro = new Random();
            int iResult;
            int iUp = 99999;
            int iDown = 10000;
            iResult = ro.Next(iDown, iUp);
            return iResult.ToString();
        }
        public static string ReservationIDgenerator()
        {
            Random ro = new Random();
            int iResult;
            int iUp = 99999;
            int iDown = 10000;
            iResult = ro.Next(iDown, iUp);
            return iResult.ToString();
        }
        public static string NoticeIDgenerator()
        {
            Random ro = new Random();
            int iResult;
            int iUp = 999;
            int iDown = 100;
            iResult = ro.Next(iDown, iUp);
            return iResult.ToString();
        }
        public static string RatingIDgenerator()
        {
            Random ro = new Random();
            int iResult;
            int iUp = 99999;
            int iDown = 10000;
            iResult = ro.Next(iDown, iUp);
            return iResult.ToString();
        }
        public static bool UniqueDoc(string identification)
        {
            DataTable dt = oracleHelper.ExecuteTable("SELECT Identification FROM DOCTOR");
            foreach(DataRow dr in dt.Rows)
            {
                if (identification == dr.DtToModel<Identification>().identification)
                    return false;
            }
            return true;
        }
        public static bool UniquePati(string identification)
        {
            DataTable dt = oracleHelper.ExecuteTable("SELECT Identification FROM PATIENT");
            foreach (DataRow dr in dt.Rows)
            {
                if (identification == dr.DtToModel<Identification>().identification)
                    return false;
            }
            return true;
        }
    }
    public class Identification
    {
        public string identification { set; get; }
    }
}
