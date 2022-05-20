using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using 后端开发.Model;
using 后端开发.Utility;

namespace 后端开发.Controllers
{
    public class PatientController : BaseController
    {
        /// <summary>
        /// 患者登录
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        public bool Login(string ID,string password)
        {
            bool isSuccessful = true;
            Patient patient = Patient.QueryByID(ID);
            if (patient == null || patient.Password != password)
                isSuccessful = false;
            return isSuccessful;
        }
        /// <summary>
        /// 患者注册
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="tel"></param>
        /// <param name="identification"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        [HttpPost]
        public string Register(string name, string password, string tel, string identification, string sex)
        {
            if (IDgenerator.UniquePati(identification) == false)
                return "false";
            string ID = IDgenerator.Pati_IDgenerator();
            string cart_ID = IDgenerator.Cart_IDgenerator(ID);
            Patient.AddPatient(ID, name, password, tel, identification, sex);
            ShoppingCart.AddShoppingcart(ID,cart_ID);
            return ID;
        }
        /// <summary>
        /// 获取患者信息
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
        /// 获取医生信息
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
        /// 患者修改个人信息
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="tel"></param>
        /// <param name="identification"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        [HttpPost]
        public bool ModInfor(string ID, string name, string password, string tel,string identification,string sex)
        {
            bool isSuccessful = true;
            Patient.AddPatient(ID, name, password, tel, identification, sex);
            return isSuccessful;
        }
        /// <summary>
        /// 患者查询疾病信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public Disease GetDisease(string name)
        {
            Disease disease = Disease.QueryByname(name);
            return disease;
        }
        /// <summary>
        /// 患者获取医生列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<DoctorInfor> GetDoctorList()
        {
            List<DoctorInfor> list = Doctor.GetDocInforList();
            return list;
        }
        /// <summary>
        /// 患者提交医生评价表
        /// </summary>
        /// <param name="pati_id"></param>
        /// <param name="doctor_id"></param>
        /// <param name="time"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost]
        public int PostRating(string pati_id,string doctor_id,string time,string content)
        {
            string number = IDgenerator.RatingIDgenerator();
            int status = RatingForm.AddEvaluation(number, pati_id, doctor_id, time, content);
            return status;
        }
        /// <summary>
        /// 患者查看医生评价列表
        /// </summary>
        /// <param name="doctor_id"></param>
        /// <returns></returns>
        [HttpGet]
        public List<RatingForm> GetRatingForm(string doctor_id)
        {
            List<RatingForm> forms = RatingForm.ListAll(doctor_id);
            return forms;
        }
       /// <summary>
       /// 患者提交预约信息
       /// </summary>
       /// <param name="pati_id"></param>
       /// <param name="doctor_id"></param>
       /// <param name="time"></param>
       /// <param name="status"></param>
       /// <returns></returns>
        [HttpPost]
        public bool PostReservation(string pati_id, string doctor_id, DateTime time,string status)
        {
            bool isSuccessful = true;
            string reservation_number = IDgenerator.ReservationIDgenerator();
            ReservationList.AddReservation(reservation_number, pati_id, doctor_id,time,status);
            return isSuccessful;
        }
        /// <summary>
        /// 患者查询预约信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ReservationList> GetReservations(string ID)
        {
            List<ReservationList> list = ReservationList.ListAll(ID);
            return list;
        }
        /// <summary>
        /// 患者获取购物车
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public ShoppingCart GetCart(string ID)
        {
             ShoppingCart cart = ShoppingCart.ShowObject(ID);
            return cart;
        }
        /// <summary>
        /// 患者通过药物种类来查询药物
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Drug> GetDrugsByType(string category)
        {
            List<Drug> list = Drug.QueryByType(category);
            return list;
        }
        /// <summary>
        /// 患者通过药物名字来查询药物
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public Drug GetDrugByName(string name)
        {
            Drug drug = Drug.QueryByName(name);
            return drug;
        }
        /// <summary>
        /// 患者获取药物信息列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Drug> GetDrugInforList()
        {
            List<Drug> list = Drug.ListAll();
            return list;
        }
        /// <summary>
        /// 患者向购物车加入药物或者减少药物
        /// </summary>
        /// <param name="Medicine_ID"></param>
        /// <param name="Pati_ID"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddDrug(string Medicine_ID, string Pati_ID, int quantity)
        {
           int status = Add.AddDrug(Medicine_ID, Pati_ID, quantity);
           return status;
        }
        /// <summary>
        /// 患者清空购物车
        /// </summary>
        /// <param name="Pati_ID"></param>
        /// <returns></returns>
        [HttpPost]
        public int EmptyCart(string Pati_ID)
        {
            int status = Add.EmptyCart(Pati_ID);
            return status;
        }
        /// <summary>
        /// 患者提交请求
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="time"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost]
        public string PostApp(string ID, DateTime time, string content)
        {
            string status = "请求已提交";
            string number = IDgenerator.Pati_IDgenerator();
            ApplicationFromPati.AddApp(number, ID, time, content);
            return status;
        }
        /// <summary>
        /// 患者获取科室所属医院表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<DepartmentToHos> GetDepartmentToHos()
        {
            List<DepartmentToHos> list = DepartmentToHos.ListAll();
            return list;
        }
        /// <summary>
        /// 患者注销账号
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        public int CancelAccount(string ID)
        {
            int status = Patient.DelPatient(ID);
            return status;
        }
        /// <summary>
        /// 患者预约核算检测
        /// </summary>
        /// <param name="pati_id"></param>
        /// <param name="hos_name"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        public int PostAppOfNuc(string pati_id,string hos_name,string status)
        {
            DateTime time = DateTime.Now;
            int result = OfflineNucleic.PostNucleicApp(pati_id, hos_name, time,status);
            return result;
        }
        /// <summary>
        /// 患者查询核算检验预约记录
        /// </summary>
        /// <param name="pati_id"></param>
        /// <returns></returns>
        [HttpGet]
        public List<OfflineNucleic> GetAppsOfNuc(string pati_id)
        {
            List<OfflineNucleic> list = OfflineNucleic.GetRecord(pati_id);
            return list;
        }
        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Department> GetDepartmentList()
        {
            List<Department> list = Department.ListAll();
            return list;
        }
        /// <summary>
        /// 获取医院列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Hospital> GetHospitalList()
        {
            List<Hospital> list = Hospital.ListAll();
            return list;
        }
        /// <summary>
        /// 获取包含列表
        /// </summary>
        /// <param name="pre_id"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Include> GetIncludeList(string pre_id)
        {
            List<Include> list = Include.GetIncludeList(pre_id);
            return list;
        }
        /// <summary>
        /// 患者提交线下问诊表
        /// </summary>
        /// <param name="pati_id"></param>
        /// <param name="hos_name"></param>
        /// <param name="department"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [HttpPost]
        public int PostOfflineApp(string pati_id, string hos_name, string department, DateTime time)
        {
            int result = OfflineAppointment.AddAppointment(pati_id,hos_name,department,time);
            return result;
        }
        /// <summary>
        /// 患者查看线下预约记录
        /// </summary>
        /// <param name="pati_id"></param>
        /// <returns></returns>
        [HttpGet]
        public List<OfflineAppointment> GetOfflineAppList(string pati_id)
        {
            List<OfflineAppointment> list = OfflineAppointment.ListAll(pati_id);
            return list;
        }
        /// <summary>
        /// 获取患者健康信息
        /// </summary>
        /// <param name="pati_id"></param>
        /// <returns></returns>
        [HttpGet]
        public Pati_infor GetPatiInfor(string pati_id)
        {
            Pati_infor patiInfor = Pati_infor.Find(pati_id);
            return patiInfor;
        }
       /// <summary>
       /// 患者提交健康信息
       /// </summary>
       /// <param name="id"></param>
       /// <param name="height"></param>
       /// <param name="weight"></param>
       /// <param name="BMI"></param>
       /// <param name="heartRate"></param>
       /// <param name="systolic_pressure"></param>
       /// <param name="diastolic_pressure"></param>
       /// <returns></returns>
        [HttpPost]
        public int PostPatiInfor(string id, string height, string weight, string BMI, string heartRate, string systolic_pressure, string diastolic_pressure)
        {
            int status = Pati_infor.AddInfor(id, height, weight, BMI, heartRate, systolic_pressure,diastolic_pressure);
            return status;
        }
        /// <summary>
        /// 患者获取电子处方
        /// </summary>
        /// <param name="pati_id"></param>
        /// <param name="doctor_id"></param>
        /// <returns></returns>
        [HttpGet]
        public ElectronicPre GetPre(string pati_id,string doctor_id)
        {
            ElectronicPre pre = ElectronicPre.Find(pati_id, doctor_id);
            return pre;
        }
        /// <summary>
        /// 患者获取疾病列表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Disease> GetDiseaseList()
        {
            List<Disease> list = Disease.ListAll();
            return list;
        }
        /// <summary>
        /// 患者根据医院名获取医院信息
        /// </summary>
        /// <param name="hos_name"></param>
        /// <returns></returns>
        [HttpGet]
        public Hospital GetHospital(string hos_name)
        {
            Hospital hospital = Hospital.Query(hos_name);
            return hospital;
        }
        /// <summary>
        /// 患者自动加购药品
        /// </summary>
        /// <param name="pati_id"></param>
        /// <param name="pre_id"></param>
        /// <returns></returns>
        [HttpPost]
        public string AutoAddDrug(string pati_id,string pre_id)
        {
            string result = Drug.AutoAdd(pati_id, pre_id);
            return result;
        }
        /// <summary>
        /// 患者修改预约表状态
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
        /// <summary>
        /// 患者修改核算预约状态
        /// </summary>
        /// <param name="pati_id"></param>
        /// <param name="time"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        public int RectifyNucleicApp(string pati_id,DateTime time, string status)
        {
            int result = OfflineNucleic.RectifyNucleicApp(pati_id,time, status);
            return result;
        }
        /// <summary>
        /// 患者修改线下预约状态
        /// </summary>
        /// <param name="pati_id"></param>
        /// <param name="time"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        public int RectifyOfflineApp(string pati_id, DateTime time,string status)
        {
            int result = OfflineAppointment.RectifyOfflineApp(pati_id,time,status);
            return result;
        }
    }
}