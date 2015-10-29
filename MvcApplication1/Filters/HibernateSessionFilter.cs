using System.Diagnostics;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using NHibernate;
using NHibernate.Context;

namespace MvcApplication1.Filters
{
    public class HibernateSessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Debug.WriteLine("Opening Hibernate Session.");
            CurrentSessionContext.Bind(HibernateConfig.SessionFactory.OpenSession());
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            ISession session = CurrentSessionContext.Unbind(HibernateConfig.SessionFactory);
            session.Flush();
            session.Close();
            session.Dispose();
            Debug.WriteLine("Closed Hibernate Session.");
        }
    }
}