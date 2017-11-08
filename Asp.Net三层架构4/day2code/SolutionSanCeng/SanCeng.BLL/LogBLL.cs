using SanCeng.DAL;
using SanCeng.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanCeng.BLL
{
    public class LogBLL
    {
        private LogDAL dal = new LogDAL();
        public long Add(long userId, string message)
        {
            return dal.Add(userId, message);
        }

        public void Delete(long id)
        {
            dal.Delete(id);
        }

        public void Update(Log log)
        {
            dal.Update(log);
        }

        /*
        public Log GetById(long id)
        {
            return dal.GetById(id);
        }

        public IEnumerable<Log> GetAll()
        {
            return dal.GetAll();
        }*/

        public LogDTO GetById(long id)
        {
            return dal.GetById(id);
        }

        public IEnumerable<LogDTO> GetAll()
        {
            return dal.GetAll();
        }

        public IEnumerable<LogDTO> Search(string word)
        {
            return dal.Search(word);
        }
    }
}
