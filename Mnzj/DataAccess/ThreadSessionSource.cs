using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mnzj.DataAccess
{
    using NHibernate;
    using System;

    public class ThreadSessionSource
    {
        [ThreadStatic]
        private static ISession session;

        public ISession Session
        {
            get
            {
                if (session != null)
                {
                    if (!session.IsConnected)
                    {
                        session.Reconnect();
                    }
                }
                return session;
            }
            set
            {
                //if (value.IsConnected)
                //{
                //    value.Disconnect();
                //}
                session = value;
            }
        }
    }
}