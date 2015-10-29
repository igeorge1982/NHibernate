using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using NHibernate;

namespace MvcApplication1.Transactions
{
    public class TransactionalAttribute : HandlerAttribute
    {
        private IsolationLevel isolationLevel = IsolationLevel.Unspecified;

        public TransactionalAttribute()
        {
        }

        public TransactionalAttribute(IsolationLevel isolationLevel)
        {
            this.isolationLevel = isolationLevel;
        }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new TransactionalCallHandler
            {
                Order = 1,
                IsolationLevel = isolationLevel,
                SessionFactory = container.Resolve<ISessionFactory>()
            };
        }
    }
}