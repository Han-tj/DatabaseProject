using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using 后端开发.Utility;

namespace 后端开发.Model
{
    public class Chat
    {
        public string Client_ID { set; get; }
        public string Server_ID { set; get; }
        public string Client_name { set; get; }
        public string Server_name { set; get; }
        public string Content { set; get; }
        public DateTime Time { set; get; }
        public string Tag { set; get; }
        public Chat() { }
        public Chat(string client_id,string server_id,string client_name,string server_name,string content,DateTime time,string tag)
        {
            Client_ID = client_id;
            Server_ID = server_id;
            Time = time;
            Client_name = client_name;
            Server_name = server_name;
            Content = content;
            Tag = tag;
        }
        public static Chat Send(string client_id,string server_id,string content,string tag)
        {
            Patient patient = Patient.QueryByID(client_id);
            Doctor doctor = Doctor.Find(server_id);
            DateTime time = DateTime.Now;
            Chat chat = new Chat(patient.Pati_ID, doctor.Doctor_ID,patient.Pati_name, doctor.Doctor_name, content, time,tag);
            oracleHelper.ExecuteNonQuery("INSERT INTO CHAT(Client_ID,Server_ID,Client_name,Server_name,Content,Time,Tag) VALUES(:Client_ID,:Server_ID,:Client_name,:Server_name,:Content,:Time,:Tag)",
                new OracleParameter(":Client_ID", patient.Pati_ID),
                new OracleParameter(":Server_ID", doctor.Doctor_ID),
                new OracleParameter(":Client_name", patient.Pati_name),
                new OracleParameter(":Server_name", doctor.Doctor_name),
                new OracleParameter(":Content", content),
                new OracleParameter(":Time", time),
                new OracleParameter(":Tag",tag)
                );
            return chat;
        }
        public static List<Chat> Receive(string client_ID,string server_ID)
        {
            List<Chat> list = new List<Chat>();
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM CHAT WHERE Client_ID = :Client_ID AND Server_ID = :Server_ID",
                new OracleParameter(":Client_ID", client_ID),
                new OracleParameter(":Server_ID", server_ID)
                );
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr.DtToModel<Chat>());
            }
            return list;
        }
        public static bool Trigger(string client_ID,string server_ID)
        {
            DataTable dt = oracleHelper.ExecuteTable("SELECT * FROM CHAT WHERE Client_ID = :Client_ID AND Server_ID = :Server_ID",
                new OracleParameter(":Client_ID", client_ID),
                new OracleParameter(":Server_ID", server_ID)
                );
            int number = dt.Rows.Count;
            if (number == 0)
                return false;
            DataTable dtable = oracleHelper.ExecuteTable("SELECT * FROM CHAT_NUMBER WHERE Client_ID = :Client_ID AND Server_ID = :Server_ID",
                new OracleParameter(":Client_ID", client_ID),
                new OracleParameter(":Server_ID", server_ID)
                );
            ChatRecordNumber record = null;
            if (dtable.Rows.Count > 0)
                record = dtable.Rows[0].DtToModel<ChatRecordNumber>();
            if(record == null && number > 0)
            {
                decimal count = 1;
                oracleHelper.ExecuteNonQuery("INSERT INTO CHAT_NUMBER(Client_ID,Server_ID,Count) VALUES(:Client_ID,:Server_ID,:Count)",
                    new OracleParameter(":Client_ID", client_ID),
                    new OracleParameter(":Server_ID", server_ID),
                    new OracleParameter(":Count", count)
                    );
                return true;
            }
            if (record.Count > 0 && record.Count == number)
                return false;
            oracleHelper.ExecuteNonQuery("UPDATE CHAT_NUMBER SET Count = :Count",
                new OracleParameter(":Number", number)
                );
            return true;
        }
    }
    public class ChatRecordNumber
    {
        public string Client_ID { set; get; }
        public string Server_ID { set; get; }
        public decimal Count { set; get; }
    }
}
