using SanCeng.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanCeng.DAL
{
    public class LogDAL
    {
        public long Add(long userId,string message)
        {
            object obj = SqlHelper.ExecuteScalar("Insert into T_Logs(UserId,CreateDateTime,Message) values(@UserId,GetDate(),@Message)",
                new SqlParameter("@UserId ", userId), new SqlParameter("@Message", message));
            return Convert.ToInt64(obj);
        }

        public void Delete(long id)
        {
            SqlHelper.ExecuteNonQuery("delete from T_Logs where Id=@Id",
                new SqlParameter("@Id",id));
        }

        public void Update(Log log)
        {
            SqlHelper.ExecuteNonQuery("Update T_Logs set UserId=@UserId,CreateDateTime=@CreatDateTime,Message=@Message where Id=@Id",
                new SqlParameter("@UserId",log.UserId),
                new SqlParameter("@CreatDateTime", log.CreateDateTime),
                new SqlParameter("@Message", log.Message),
                new SqlParameter("@Id", log.Id));
        }

        /*
        private Log ToLog(DataRow row)
        {
            Log log = new Log();
            log.Id = (long)row["Id"];
            log.Message = (string)row["Message"];
            log.UserId = (long)row["UserId"];
            log.CreateDateTime = (DateTime)row["CreateDateTime"];
            return log;
        }

        public Log GetById(long id)
        {
            DataTable dt = SqlHelper.ExecuteQuery("select * from T_Logs where Id=@Id",
                new SqlParameter("@Id",id));
            if(dt.Rows.Count<=0)
            {
                return null;
            }
            else if(dt.Rows.Count>1)
            {
                throw new ApplicationException("找到多个id重复的数据");
            }
            else
            {
                DataRow row = dt.Rows[0];
                return ToLog(row);
            }
        }

        public IEnumerable<Log> GetAll()
        {
            DataTable dt = SqlHelper.ExecuteQuery("select * from T_Logs");
            List<Log> list = new List<Log>();
            foreach(DataRow row in dt.Rows)
            {
                Log log = ToLog(row);
                list.Add(log);//list.Add(ToLog(row));
            }
            return list;
        }*/

        private LogDTO ToLogDTO(DataRow row)
        {
            LogDTO log = new LogDTO();
            log.Id = (long)row["Id"];
            log.Message = (string)row["Message"];
            log.UserName = (string)row["UserName"];
            log.CreateDateTime = (DateTime)row["CreateDateTime"];
            log.UserPhoneNum = (string)row["PhoneNum"];
            return log;
        }

        public LogDTO GetById(long id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select log.Id,log.UserId,u.UserName,u.PhoneNum,log.CreateDateTime,log.Message");
            sb.AppendLine("from T_Logs log");
            sb.AppendLine("left join T_Users u on log.UserId=u.Id");
            sb.AppendLine("Where log.Id=@Id");
            /*
            DataTable dt = SqlHelper.ExecuteQuery("select * from T_Logs where Id=@Id",
                new SqlParameter("@Id", id));*/
            DataTable dt = SqlHelper.ExecuteQuery(sb.ToString(), new SqlParameter("@Id", id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count > 1)
            {
                throw new ApplicationException("找到多个id重复的数据");
            }
            else
            {
                DataRow row = dt.Rows[0];
                return ToLogDTO(row);
            }
        }

        public IEnumerable<LogDTO> GetAll()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select log.Id,log.UserId,u.UserName,u.PhoneNum,log.CreateDateTime,log.Message");
            sb.AppendLine("from T_Logs log");
            sb.AppendLine("left join T_Users u on log.UserId=u.Id");
            DataTable dt = SqlHelper.ExecuteQuery(sb.ToString());
            List<LogDTO> list = new List<LogDTO>();
            foreach (DataRow row in dt.Rows)
            {
                LogDTO log = ToLogDTO(row);
                list.Add(log);//list.Add(ToLog(row));
            }
            return list;
        }


        public IEnumerable<LogDTO> Search(string word)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select log.Id,log.UserId,u.UserName,u.PhoneNum,log.CreateDateTime,log.Message");
            sb.AppendLine("from T_Logs log");
            sb.AppendLine("left join T_Users u on log.UserId=u.Id");
            sb.AppendLine("where log.Message like @Word");
            DataTable dt = SqlHelper.ExecuteQuery(sb.ToString(),
                new SqlParameter("@Word","%"+word+"%"));
            List<LogDTO> list = new List<LogDTO>();
            foreach (DataRow row in dt.Rows)
            {
                LogDTO log = ToLogDTO(row);
                list.Add(log);//list.Add(ToLog(row));
            }
            return list;
        }
    }
}
