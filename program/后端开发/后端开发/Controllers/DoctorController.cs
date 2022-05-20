using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using 后端开发.Model;

namespace 后端开发.Controllers
{
    public class DoctorController : BaseController
    {
        /// <summary>
        /// 医生登录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        public bool Login(string id,string password)
        {
            Doctor doctor = Doctor.Find(id);
            bool isSuccessful = true;
            if (doctor == null || doctor.Password != password)
                isSuccessful = false;
            return isSuccessful;
        }
        /// <summary>
        /// 获取医生个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Doctor GetDoctor(string id)
        {
            Doctor doctor = Doctor.Find(id);
            return doctor;
        }
        /// <summary>
        /// 医生注册
        /// </summary>
        /// <param name="identification"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="workingAge"></param>
        /// <param name="sex"></param>
        /// <param name="title"></param>
        /// <param name="hosname"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public string Register(string identification, string name, string password, string workingAge, string sex, string title, string hosname, string department)
        {
            if (IDgenerator.UniqueDoc(identification) == false)
                return "false";
            string introduction = "无";
            int picture_number = 0;
            string ID = IDgenerator.Doctor_IDgenerator();
            Doctor.AddDoctor(ID, identification, name, password, workingAge, sex, title, hosname, department,introduction,picture_number);
            return ID;
        }
        /// <summary>
        /// 医生修改个人信息
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="identification"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="workingAge"></param>
        /// <param name="sex"></param>
        /// <param name="title"></param>
        /// <param name="hosname"></param>
        /// <param name="department"></param>
        /// <param name="introduction"></param>
        /// <param name="picture_number"></param>
        /// <returns></returns>
        [HttpPost]
        public int ModInfor(string ID, string identification, string name, string password, string workingAge, string sex, string title, string hosname, string department, string introduction, int picture_number)
        {
            int status = Doctor.ModDoctorInfor(ID,identification,name,password,workingAge,sex,title,hosname,department,introduction,picture_number);
            return status;
        }
        /// <summary>
        /// 获取患者个人信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public Patient GetPatient(string ID)
        {
            Patient patient = Patient.QueryByID(ID);
            return patient;
        }
        /// <summary>
        /// 医生查询问诊记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Record> GetRecords(string ID)
        {
            List<Record> records = Record.GetRecords(ID);
            return records;
        }
        /// <summary>
        /// 医生开具电子处方
        /// </summary>
        /// <param name="Pati_ID"></param>
        /// <param name="Doctor_ID"></param>
        /// <param name="department"></param>
        /// <param name="time"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost]
        public ElectronicPre PostPre(string Pati_ID, string Doctor_ID, string department, DateTime time, string content)
        {
            string pre_ID = IDgenerator.Pre_IDgenerator();
            ElectronicPre.AddPre(pre_ID, Pati_ID, Doctor_ID, department, time, content);
            ElectronicPre pre = ElectronicPre.Find(Pati_ID, Doctor_ID);
            return pre;
        }
        /// <summary>
        /// 医生修改疾病信息
        /// </summary>
        /// <param name="Doctor_ID"></param>
        /// <param name="Disease_name"></param>
        /// <param name="Pathogeny"></param>
        /// <param name="Symptoms"></param>
        /// <param name="Complication"></param>
        /// <param name="Medication"></param>
        /// <param name="Introduction"></param>
        /// <returns></returns>
        [HttpPost]
        public string ModDisease(string Doctor_ID,string Disease_name,string Pathogeny,string Symptoms,string Complication,string Medication,string Introduction)
        {
            string Status = "修改成功";
            Disease.AddDisease(Disease_name, Pathogeny, Symptoms, Complication, Medication,Introduction);
            Modification.AddMod(Doctor_ID, Disease_name);
            return Status;
        }
        /// <summary>
        /// 医生发起举报
        /// </summary>
        /// <param name="pati_id"></param>
        /// <param name="doctor_id"></param>
        /// <param name="time"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost]
        public string PostReport(string pati_id, string doctor_id, DateTime time, string content)
        {
            string status = "举报已提交";
            string report_number = IDgenerator.Report_IDgenerator();
            ReportForm.AddReport(report_number, pati_id, doctor_id, time, content);
            return status;
        }
        /// <summary>
        /// 医生提交请求
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="workingAge"></param>
        /// <param name="hosName"></param>
        /// <param name="department"></param>
        /// <param name="introduction"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        public string PostApp(string ID, string workingAge, string hosName, string department, string introduction, string status)
        {
            string result = "请求已提交";
            string number = IDgenerator.App_IDgenerator();
            ApplicationFromDoc.AddApp(number, ID, workingAge,hosName,department,introduction,status);
            return result;
        }
        /// <summary>
        /// 提交包含表
        /// </summary>
        /// <param name="m_name"></param>
        /// <param name="p_id"></param>
        /// <param name="quantity"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost]
        public int PostInclude(string m_name, string p_id, string quantity, string content)
        {
            int status = Include.AddInclude(m_name, p_id, quantity, content);
            return status;
        }
        [HttpPost]
        public int RectifyOnlineInquiry(string pati_id,string doctor_id, string status)
        {
            int result = OnlineInquiry.RectifyOnlineInqury(pati_id, doctor_id, status);
            return result;
        }
        /// <summary>
        /// 医生查询预约信息
        /// </summary>
        /// <param name="doctor_id"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ReservationList> GetReservationLists(string doctor_id)
        {
            List<ReservationList> list = ReservationList.GetReservationLists(doctor_id);
            return list;
        }
        /// <summary>
        /// 医生修改预约表状态
        /// </summary>
        /// <param name="reservation_number"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        public int UpdateReservation(string reservation_number,string status)
        {
            int result = ReservationList.UpdateReservation(reservation_number, status);
            return result;
        }
    }
}