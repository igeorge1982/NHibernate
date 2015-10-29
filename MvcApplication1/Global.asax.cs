using System.Web;
using System.Web.Http;

namespace MvcApplication1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // Web Api 1
            // WebApiConfig.Register(GlobalConfiguration.Configuration);

            // Web Api 2
            GlobalConfiguration.Configure(WebApiConfig.Register);
            WebApiFilterConfig.RegisterGlobalFilters(GlobalConfiguration.Configuration.Filters);

            HibernateConfig.InitHibernate();

            UnityBootstrapper.Initialise();
        }

        public override void Dispose()
        {
            HibernateConfig.SessionFactory.Dispose();
            base.Dispose();
        }
    }
}