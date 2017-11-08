using SanCeng.DAL;
using SanCeng.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanCeng.BLL
{
    public class UserBLL
    {
        private UserDAL uDAL = new UserDAL();

        public long Add2(string userName, string password, string phoneNum, int? age,out bool isExist)
        {
            if (GetByUserName(userName)!=null)
            {
                isExist = true;
                return 0;
            }
            else
            {
                isExist = false;
                long id = uDAL.Add(userName, password, phoneNum, age);
                new LogBLL().Add(id, "新增用户" + userName);//
                return id;
            }            
        }

        public long Add(string userName, string password, string phoneNum, int? age)
        {
            return uDAL.Add(userName, password, phoneNum, age);
        }

        public void Delete(long id)
        {
            uDAL.Delete(id);
        }

        public void Update(User user)
        {
            uDAL.Update(user);
        }

        public User GetById(long id)
        {
            return uDAL.GetById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return uDAL.GetAll();
        }

        public User GetByUserName(string userName)
        {
            return uDAL.GetByUserName(userName);
        }

        public LoginResult Login(string userName,string password)
        {
            User u = this.GetByUserName(userName);
            if(u==null)
            {
                return LoginResult.UserNameNotFound;
            }
            else if(u.Password!=password)
            {
                return LoginResult.PasswordError;
            }
            else
            {
                new LogBLL().Add(u.Id, u.UserName + "登录了系统");
                return LoginResult.OK;
            }
        }
    }
}
