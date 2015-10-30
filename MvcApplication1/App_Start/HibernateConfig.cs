using System.Diagnostics;
using System.IO;
using System.Reflection;
using log4net;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.Attributes;
using Environment = System.Environment;

namespace MvcApplication1
{
    public static class HibernateConfig
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        public static ISessionFactory SessionFactory { get; private set; }

        public static void InitHibernate()
        {
            Debug.WriteLine("Configuring Hibernate...");
            Log.Info("hello");
            var cfg = new Configuration();

            HbmSerializer.Default.Validate = true;

            HbmSerializer.Default.Serialize(Environment.CurrentDirectory, Assembly.GetExecutingAssembly());
            cfg.AddDirectory(new DirectoryInfo(Environment.CurrentDirectory));

            var sessionFactory = cfg.Configure().BuildSessionFactory();
            SessionFactory = sessionFactory;
            Debug.WriteLine("Created SessionFactory!");
        }
    }
}