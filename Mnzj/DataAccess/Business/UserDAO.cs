using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mnzj.Entity;
using NHibernate;
using System.Diagnostics;

namespace Mnzj.DataAccess.Business
{
    public class UserDAO
    {
        public UserDAO()
        {
        }

        private static UserDAO _instance = null;

        public static UserDAO GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserDAO();
            }
            return _instance;
        }

        /// <summary>
        /// 查询所有用户信息
        /// </summary>
        /// <returns></returns>
        public IList<User> QueryAll()
        {
            List<User> ret = new List<User>();
            try
            {
                ISession session = NHibernateDatabaseFactory.CreateSession();
                return session.QueryOver<User>().List();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return ret;
        }

        /// <summary>
        /// 查询一个用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户</returns>
        public User Query(string userName, string password = "")
        {
            try
            {
                ISession session = NHibernateDatabaseFactory.CreateSession();
                if(string.IsNullOrEmpty(password))
                    return session.QueryOver<User>().Where(p => p.Name == userName).List().FirstOrDefault();
                else
                    return session.QueryOver<User>().Where(p => p.Name == userName && p.Password == password).List().FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());                
            }
            return null;
        }

        /// <summary>
        /// 保存/更新 用户信息
        /// </summary>
        /// <param name="user"></param>
        public void Save(User user)
        {
            try
            {
                ISession session = NHibernateDatabaseFactory.CreateSession();
                session.SaveOrUpdate(user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());                 
            }
        }
    }
}