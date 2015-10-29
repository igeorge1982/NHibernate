using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using Microsoft.Practices.Unity.InterceptionExtension;
using NHibernate;

namespace MvcApplication1.Transactions
{
    public class TransactionalCallHandler : ICallHandler
    {
        public int Order { get; set; }

        public ISessionFactory SessionFactory { private get; set; }

        public IsolationLevel IsolationLevel { private get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            ISession session = SessionFactory.GetCurrentSession();

            ITransaction transaction = null;
            if (IsolationLevel == IsolationLevel.Unspecified)
            {
                transaction = session.BeginTransaction();
            }
            else
            {
                transaction = session.BeginTransaction(IsolationLevel);
            }
            Debug.WriteLine("Started transaction");

            IMethodReturn result = getNext()(input, getNext);

            if (result.Exception != null)
            {
                transaction.Rollback();
                Debug.WriteLine("Rolled transaction");
            }
            else
            {
                transaction.Commit();
                Debug.WriteLine("Committed transaction");
            }
            transaction.Dispose();

            return result;
        }
    }
}