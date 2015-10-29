using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using MvcApplication1.Filters;

namespace MvcApplication1
{
    public class WebApiFilterConfig
    {
        public static void RegisterGlobalFilters(HttpFilterCollection filters)
        {
            filters.Add(new HibernateSessionFilter());
        }
    }
}