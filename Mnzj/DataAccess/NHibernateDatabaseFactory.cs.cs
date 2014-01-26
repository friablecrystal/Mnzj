using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mnzj.DataAccess
{
    using NHibernate;
    using NHibernate.Cfg;

    /// <summary>
    /// 用来生成ISession实例的工厂
    /// </summary>
    public static class NHibernateDatabaseFactory
    {
        #region 私有静态变量

        private static object m_Locker = new object();
        private static Configuration m_Configuration = null;
        private static ISessionFactory m_SessionFactory = null;
        private static ThreadSessionSource m_Sessionsource;

        #endregion

        #region 静态构造函数

        static NHibernateDatabaseFactory()
        {
            m_Sessionsource = new ThreadSessionSource();
        }

        #endregion

        #region 内部静态变量

        /// <summary>
        /// NHibernate配置对象
        /// </summary>
        public static Configuration Configuration
        {
            get
            {
                lock (m_Locker)
                {
                    if (m_Configuration == null)
                    {
                        CreateConfiguration();
                    }
                    return m_Configuration;
                }
            }
            set { m_Configuration = value; }
        }

        /// <summary>
        /// NHibernate的对象工厂
        /// </summary>
        internal static ISessionFactory SessionFactory
        {
            get
            {
                if (null == m_SessionFactory)
                {
                    if (m_Configuration == null)
                    {
                        CreateConfiguration();
                    }
                    lock (m_Locker)
                    {
                        m_SessionFactory = Configuration.BuildSessionFactory();
                    }
                }

                return m_SessionFactory;
            }
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 建立ISessionFactory的实例
        /// </summary>
        /// <returns></returns>
        public static ISession CreateSession()
        {
            ISession s = m_Sessionsource.Session;
            if (s == null)
            {
                s = SessionFactory.OpenSession();

                m_Sessionsource.Session = s;
            }
            if (!s.IsConnected)
                s.Reconnect();
            return s;
        }

        #endregion

        #region 私有方法

        private static void CreateConfiguration()
        {
            m_Configuration = new Configuration();
            m_Configuration.Configure(AppDomain.CurrentDomain.RelativeSearchPath + "\\cfg\\Nhibernate.cfg.xml");
        }

        #endregion
    }
}