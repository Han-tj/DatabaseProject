using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using 后端开发.Model;

namespace 后端开发.Controllers
{
    public class AdminController : BaseController
    {
        /// <summary>
        /// 获取患者请求列表清单
        /// </summary>
        /// <returns></returns>
       [HttpGet]
       public List<ApplicationFromPati> GetPatiAppForms()
        {
            List<ApplicationFromPati> forms = ApplicationFromPati.GetAppList();
            return forms;
        }
        /// <summary>
        /// 获取医生请求列表清单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ApplicationFromDoc> GetDocAppForms()
        {
            List<ApplicationFromDoc> forms = ApplicationFromDoc.GetAppList();
            return forms;
        }
        /// <summary>
        /// 获取举报列表清单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ReportForm> GetReportForms()
        {
            List<ReportForm> forms = ReportForm.listAll();
            return forms;
        }
        /// <summary>
        /// 查看详细患者请求内容
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet]
        public ApplicationFromPati GetPatiApp(string number)
        {
            ApplicationFromPati form = ApplicationFromPati.Find(number);
            return form;
        }
        /// <summary>
        /// 查看详细医生请求内容
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet]
        public ApplicationFromDoc GetDocApp(string number)
        {
            ApplicationFromDoc form = ApplicationFromDoc.Find(number);
            return form;
        }
        /// <summary>
        /// 查看详细举报内容
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet]
        public ReportForm GetReport(string number)
        {
            ReportForm form = ReportForm.Find(number);
            return form;
        }
        /// <summary>
        /// 审核患者请求
        /// </summary>
        /// <param name="req_number"></param>
        /// <param name="Admin_ID"></param>
        /// <returns></returns>
        [HttpPost]
        public int AuditPatiApp(string req_number, string Admin_ID)
        {
            int status = Administrator.AuditPatiApp(req_number, Admin_ID);
            return status;
        }
        /// <summary>
        /// 审核医生请求
        /// </summary>
        /// <param name="req_number"></param>
        /// <param name="Admin_ID"></param>
        /// <returns></returns>
        [HttpPost]
        public int AuditDocApp(string req_number,string Admin_ID)
        {
            int status = Administrator.AuditDocApp(req_number, Admin_ID);
            return status;
        }
        /// <summary>
        /// 审核举报
        /// </summary>
        /// <param name="report_number"></param>
        /// <param name="Admin_ID"></param>
        /// <returns></returns>
        [HttpPost]
        public int AuditReport(string report_number, string Admin_ID)
        {
            int status = Administrator.AuditReport(report_number, Admin_ID);
            return status;
        }
        /// <summary>
        /// 管理员发布公告
        /// </summary>
        /// <param name="noticeName"></param>
        /// <param name="content"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [HttpPost]
        public int PostNotice(string noticeName,string content,string time)
        {
            string noticeID = IDgenerator.NoticeIDgenerator();
            int status = Administrator.PostNotice(noticeID,noticeName,content,time);
            return status;
        }
        /// <summary>
        /// 管理员删除公告
        /// </summary>
        /// <param name="noticeID"></param>
        /// <returns></returns>
        [HttpPost]
        public int DeleteNotice(string noticeID)
        {
            int result = Administrator.DeleteNotice(noticeID);
            return result;
        }
    }
}