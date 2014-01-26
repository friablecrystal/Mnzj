using System;
using NHibernate;
using System.Diagnostics;

namespace Mnzj.DataAccess
{
    public abstract class BasicDAO<T>
    {

        public void save(T t)
        {
            try
            {
                ISession session = NHibernateDatabaseFactory.CreateSession();
                session.Save(t);
                session.Flush();
            }
            catch (Exception e)
            {
                Debug.WriteLine("存储数据出错！");
                //throw e;
            }
        }

        public void delete(T t)
        {
            try
            {
                ISession session = NHibernateDatabaseFactory.CreateSession();
                session.Delete(t);
                session.Flush();
            }
            catch (Exception e)
            {
                Debug.WriteLine("存储数据出错！");
                //throw e;
            }
        }

        public void update(T t)
        {
            try
            {
                ISession session = NHibernateDatabaseFactory.CreateSession();
                session.Update(t);
                session.Flush();
            }
            catch (Exception e)
            {
                Debug.WriteLine("更新数据出错！");
                //throw e;
            }
        }
    }
}