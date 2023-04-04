using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// 描述：nhibernate辅助类
    /// </summary>
    public class NHibernateHelper
    {
        public NHibernateHelper()
        {
        }
        private static ISessionFactory? SessionFactory { get; set; }

        public static ISessionFactory GetSessionFactory()
        {
            //配置ISessionFactory
            return (new Configuration()).Configure().BuildSessionFactory();
        }

        // 打开ISession
        public static ISession GetSession()
        {
            if (SessionFactory == null)
            {
                SessionFactory = GetSessionFactory();
            }
            return SessionFactory.OpenSession();
        }

        public static void CloseSession()
        {
            if (SessionFactory != null )
            {
                SessionFactory.Close();
            }
        }


        //public static string? ConnectionString { get; set; }

        //// 创建ISessionFactory
        //public static ISessionFactory GetSessionFactory<T>() where T : ICurrentSessionContext
        //{
        //    var cfg = new Configuration();

        //    cfg.DataBaseIntegration(x =>
        //    {
        //        if (!string.IsNullOrEmpty(ConnectionString)
        //            && ConnectionString.Trim() != "")
        //        {
        //            x.ConnectionString = ConnectionString;
        //        }
        //    });

        //    cfg.Configure().CurrentSessionContext<T>();
        //    return cfg.BuildSessionFactory();
        //}

        ////打开ISession
        //public static ISession GetSession()
        //{
        //    if (SessionFactory == null)
        //    {
        //        SessionFactory = GetSessionFactory<ThreadStaticSessionContext>();
        //    }
        //    if (CurrentSessionContext.HasBind(SessionFactory))
        //    {
        //        return SessionFactory.GetCurrentSession();
        //    }

        //    var session = SessionFactory.OpenSession();
        //    CurrentSessionContext.Bind(session);

        //    return session;
        //}

        ////关闭Isession
        //public static void CloseSession()
        //{
        //    if (SessionFactory != null && CurrentSessionContext.HasBind(SessionFactory))
        //    {
        //        var session = CurrentSessionContext.Unbind(SessionFactory);
        //        if (session != null && session.IsOpen)
        //        {
        //            session.Close();
        //        }
        //    }
        //}

    }
    public static class DataAccessFactory
    {
        public static dynamic CreateAccess(string TypeName)
        {
            return Activator.CreateInstance(Type.GetType(TypeName));
        }
    }

}