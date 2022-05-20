using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class Doctor
    {
        public string Doctor_ID { set; get; }
        public string Identification { set; get; }
        public string Doctor_name { set; get; }
        public string Password { set; get; }
        public string Working_age { set; get; }
        public string Sex { set; get; }
        public string Title { set; get; }
        public string Hos_name { set; get; }
        public string Department { set; get; }
        public string Picture_url { set; get; }
        public string Introduction { set; get; }
        public static Doctor Find(string ID)
        {
            Doctor doctor = null;
            DataTable dt = oracleHelper.ExecuteTable("SELECT *  FROM DOCTOR WHERE Doctor_ID=:Doctor_ID",
                new OracleParameter(":Doctor_ID", ID)
                );
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                doctor = dr.DtToModel<Doctor>();
            }
            return doctor;
        }
        public static int AddDoctor(string ID,string identification,string name,string password,string workingAge,string sex,string title,string hosname,string department,string introduction,int picture_number)
        {
            string Picture_url = "‪http://106.14.45.227:8080/" + picture_number.ToString() + ".png";
            return oracleHelper.ExecuteNonQuery("INSERT INTO DOCTOR(Doctor_ID,Identification,Doctor_name,Password,Working_age,Sex,Title,Hos_name,Department,Picture_url,Introduction) VALUES(:Doctor_ID,:Identification,:Doctor_name,:Password,:Working_age,:Sex,:Title,:Hos_name,:Department,:Picture_url,:Introduction)",
                   new OracleParameter(":Doctor_ID", ID),
                   new OracleParameter(":Identification", identification),
                   new OracleParameter(":Doctor_name", name),
                   new OracleParameter(":Password", password),
                   new OracleParameter(":Working_age", workingAge),
                   new OracleParameter(":Sex", sex),
                   new OracleParameter(":Title", title),
                   new OracleParameter(":Hos_name", hosname),
                   new OracleParameter(":Department", department),
                   new OracleParameter(":Picture_url", Picture_url),
                   new OracleParameter(":Introduction", introduction)
                   );
        }
        public static int ModDoctorInfor(string ID, string identification, string name, string password, string workingAge, string sex, string title, string hosname, string department, string introduction, int picture_number)
        {
            string Picture_url = "‪http://106.14.45.227:8080/" + picture_number.ToString() + ".png";
            oracleHelper.ExecuteNonQuery("DELETE FROM DOCTOR WHERE Doctor_ID = :Doctor_ID",
                new OracleParameter(":Doctor_ID", ID)
                );
            return oracleHelper.ExecuteNonQuery("INSERT INTO DOCTOR(Doctor_ID,Identification,Doctor_name,Password,Working_age,Sex,Title,Hos_name,Department,Picture_url,Introduction) VALUES(:Doctor_ID,:Identification,:Doctor_name,:Password,:Working_age,:Sex,:Title,:Hos_name,:Department,:Picture_url,:Introduction)",
                   new OracleParameter(":Doctor_ID", ID),
                   new OracleParameter(":Identification", identification),
                   new OracleParameter(":Doctor_name", name),
                   new OracleParameter(":Password", password),
                   new OracleParameter(":Working_age", workingAge),
                   new OracleParameter(":Sex", sex),
                   new OracleParameter(":Title", title),
                   new OracleParameter(":Hos_name", hosname),
                   new OracleParameter(":Department", department),
                   new OracleParameter(":Picture_url", Picture_url),
                   new OracleParameter(":Introduction", introduction)
                   );
        }
        public static List<DoctorInfor> GetDocInforList()
        {
            List<DoctorInfor> list = new List<DoctorInfor>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT Doctor_ID,Identification,Doctor_name,Working_age,Sex,Title,Hos_name,Department,Picture_url,Introduction FROM DOCTOR");
            foreach (DataRow dr in dt.Rows)
                list.Add(dr.DtToModel<DoctorInfor>());
            return list;
        }
    }
    public class DoctorInfor
    {
        public string Doctor_ID { set; get; }
        public string Identification { set; get; }
        public string Doctor_name { set; get; }
        public string Working_age { set; get; }
        public string Sex { set; get; }
        public string Title { set; get; }
        public string Hos_name { set; get; }
        public string Department { set; get; }
        public string Picture_url { set; get; }
        public string Introduction { set; get; }
    }
}
