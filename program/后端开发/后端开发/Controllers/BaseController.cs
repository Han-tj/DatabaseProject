using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using 后端开发.Model;

namespace 后端开发.Controllers
{
    [EnableCors("any")]
    [Route("[controller]/[Action]")]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Notice> GetNoticeList()
        {
            List<Notice> list = Notice.ListAll();
            return list;
        }
        /// <summary>
        /// 查看公告详细内容
        /// </summary>
        /// <param name="Notice_ID"></param>
        /// <returns></returns>
        [HttpGet]
        public Notice GetNotice(string Notice_ID)
        {
            Notice notice = Notice.GetNotice(Notice_ID);
            return notice;
        }
        /// <summary>
        /// 发送聊天信息
        /// </summary>
        /// <param name="client_id"></param>
        /// <param name="server_id"></param>
        /// <param name="content"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        [HttpPost]
        public Chat PostChat(string client_id, string server_id, string content,string tag)
        {
            Chat chat = Chat.Send(client_id, server_id, content,tag);
            return chat;
        }
        /// <summary>
        /// 获取聊天信息
        /// </summary>
        /// <param name="client_ID"></param>
        /// <param name="server_ID"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Chat> GetChat(string client_ID, string server_ID)
        {
            List<Chat> list = Chat.Receive(client_ID, server_ID);
            return list;
        }
    }
}