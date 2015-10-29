using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Context;

namespace MvcApplication1
{
    public static class HibernateConfig
    {
        public static ISessionFactory SessionFactory { get; private set; }

        public static void InitHibernate()
        {
            Debug.WriteLine("Configuring Hibernate...");
            Configuration cfg = new Configuration();
            ISessionFactory sessionFactory = cfg.Configure().BuildSessionFactory();
            SessionFactory = sessionFactory;
            Debug.WriteLine("Created SessionFactory!");
        }
    }
}
